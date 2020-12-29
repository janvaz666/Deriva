using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using mail.model;

namespace mail
{
    public class Correo
    {
        #region variables

        int _i;

        int _servidorPuerto;
        string _servidorDireccion;
        string _servidorUsuario;
        string _servidorContrasena;

        ResultadoEnvio _resultado;
        MailMessage _mensaje;
        MailMessage _mm;
        SmtpClient _smtp;

        public string _men;

        #endregion

        #region constructores

        public Correo()
        {
            this._servidorPuerto = 0;
            this._servidorDireccion = "127.0.0.0";
            this._servidorUsuario = string.Empty;
            this._servidorContrasena = string.Empty;
        }

        public Correo(string direccion, string usuario, string contrasena, int puerto)
        {
            this._servidorDireccion = direccion;
            this._servidorUsuario = usuario;
            this._servidorContrasena = contrasena;
            this._servidorPuerto = puerto;
        }

        #endregion

        #region métodos

        ///<summary>
        ///Método para armar el objeto con los datos del correo
        ///</summary>
        ///
        ///<parameters>
        /// <param name="destinatarios">arreglo de tipo cadena con las direcciones</param>
        ///</parameters>
        ///
        ///<returns>Objeto del tipo mailmessage con los datos</returns>
        private MailMessage CreaMensajeCorreo(string origen, string[] destinatarios, string asunto)
        {
            _mensaje = new MailMessage();

            try
            {
                //Quién envia.
                _mensaje.From = new MailAddress(origen);
                //Asunto
                _mensaje.Subject = asunto;
                //Cuerpo del correo.
                _mensaje.Body = string.Empty;
                //HTML
                _mensaje.IsBodyHtml = true;
                //Quién recibe.
                if (destinatarios.Length > 0)
                {
                    _i = 0;
                    foreach (string elm in destinatarios)
                    {
                        _mensaje.To.Add(elm);
                        _i += 1;
                    }
                }
            }
            catch (Exception ex)
            {
                _men = "creaCorreo - Error: " + ex.Message.ToString();
                _mensaje = null;
            }

            return _mensaje;
        }

        ///<summary>
        ///Método para armar el objeto con los datos del correo
        ///</summary>
        ///
        ///<parameters>
        /// <param name="destinatarios">arreglo de tipo cadena con las direcciones</param>
        ///</parameters>
        ///
        ///<returns>Objeto del tipo mailmessage con los datos</returns>
        private MailMessage CreaMensajeCorreo(string origen, string[] destinatarios, string asunto, string[] _archivos)
        {
            _mensaje = new MailMessage();

            try
            {
                //Quién envia.
                _mensaje.From = new MailAddress(origen);
                //Asunto
                _mensaje.Subject = asunto;
                //Cuerpo del correo.
                _mensaje.Body = string.Empty;
                //HTML
                _mensaje.IsBodyHtml = true;
                //Recibe archivos adjuntos
                foreach (string _attach in _archivos)
                {
                    _mensaje.Attachments.Add(new Attachment(_attach, MediaTypeNames.Application.Octet));
                }
                //Quién recibe.
                if (destinatarios.Length > 0)
                {
                    _i = 0;
                    foreach (string elm in destinatarios)
                    {
                        _mensaje.To.Add(elm);
                        _i += 1;
                    }
                }
            }
            catch (Exception ex)
            {
                _men = "creaCorreo - Error: " + ex.Message.ToString();
                _mensaje = null;
            }

            return _mensaje;
        }

        ///<summary>
        ///Método para armar realizar el envío de un correo electrónico.
        ///</summary>
        ///
        ///<parameters>
        /// <param name="datoCorreo">Objeto con los datos el correo</param>
        ///</parameters>
        ///
        ///<returns>Objeto con el resultado de la operación</returns>
        public ResultadoEnvio EnviarCorreoConCertificados(DatoCorreo datoCorreo)
        {

            try
            {
                _smtp = new SmtpClient();
                _smtp.Host = this._servidorDireccion;
                _smtp.Port = this._servidorPuerto;
                _smtp.UseDefaultCredentials = false;
                _smtp.EnableSsl = datoCorreo.EsSSL;
                _smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                if (_servidorUsuario != string.Empty && _servidorUsuario != "" && _servidorUsuario != " ")
                {
                    _smtp.Credentials = new System.Net.NetworkCredential(this._servidorUsuario, this._servidorContrasena);
                }

                _mm = new MailMessage();
                _mm = datoCorreo.Adjuntos ?
                    this.CreaMensajeCorreo(datoCorreo.Origen, datoCorreo.Destinatario, datoCorreo.Asunto, datoCorreo.RutaArchivos) :
                    this.CreaMensajeCorreo(datoCorreo.Origen, datoCorreo.Destinatario, datoCorreo.Asunto);
                _mm.Body = datoCorreo.Cuerpo;
                _mm.Body = _mm.Body;
                _mm.BodyEncoding = Encoding.UTF8;
                _mm.IsBodyHtml = datoCorreo.EsHTML;

                if (datoCorreo.EsSSL)
                {
                    // Para resolver el error:
                    // El certificado remoto no es válido según el procedimiento de validación
                    ServicePointManager.ServerCertificateValidationCallback =
                    delegate (object s
                        , X509Certificate certificate
                        , X509Chain chai
                        , SslPolicyErrors sslPolicyErrors)
                    { return true; };
                }


                if (_mm != null)
                {
                    _smtp.Send(_mm);
                    _resultado = new ResultadoEnvio(1, "OK");
                }
                else
                {
                    _resultado = new ResultadoEnvio(-1, _men);
                }

            }
            catch (Exception ex)
            {
                _resultado = new ResultadoEnvio(-1, ex.Message.ToString());
            }

            return _resultado;
        }

        ///<summary>
        ///Método para armar realizar el envío de un correo electrónico.
        ///No se genera certificado de seguridad (servidores SMTP MS).
        ///</summary>
        ///
        ///<parameters>
        /// <param name="datoCorreo">Objeto con los datos el correo</param>
        ///</parameters>
        ///
        ///<returns>Objeto con el resultado de la operación</returns>
        public ResultadoEnvio EnviarCorreo(DatoCorreo datoCorreo)
        {

            try
            {
                _smtp = new SmtpClient();
                _smtp.Host = this._servidorDireccion;
                _smtp.Port = this._servidorPuerto;
                _smtp.UseDefaultCredentials = false;
                _smtp.EnableSsl = datoCorreo.EsSSL;
                _smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                if (_servidorUsuario != string.Empty && _servidorUsuario != "" && _servidorUsuario != " ")
                {
                    _smtp.Credentials = new System.Net.NetworkCredential(this._servidorUsuario, this._servidorContrasena);
                }

                _mm = new MailMessage();
                _mm = datoCorreo.Adjuntos ?
                    this.CreaMensajeCorreo(datoCorreo.Origen, datoCorreo.Destinatario, datoCorreo.Asunto, datoCorreo.RutaArchivos) : 
                    this.CreaMensajeCorreo(datoCorreo.Origen, datoCorreo.Destinatario, datoCorreo.Asunto);
                _mm.Body = datoCorreo.Cuerpo;
                _mm.Body = _mm.Body;
                _mm.BodyEncoding = Encoding.UTF8;
                _mm.IsBodyHtml = datoCorreo.EsHTML;

                if (_mm != null)
                {
                    _smtp.Send(_mm);
                    _resultado = new ResultadoEnvio(1, "OK");
                }
                else
                {
                    _resultado = new ResultadoEnvio(-1, _men);
                }

            }
            catch (Exception ex)
            {
                _resultado = new ResultadoEnvio(-1, ex.Message.ToString());
            }

            return _resultado;
        }

        #endregion
    }
}
