
namespace mail.model
{
    public class DatoCorreo
    {
        #region propiedades 

        public string Asunto { get; set; }
        public string Origen { get; set; }
        public string[] Destinatario { get; set; }
        public string Cuerpo { get; set; }
        public bool EsHTML { get; set; }
        public bool EsSSL { get; set; }
        public bool Adjuntos { get; set; }
        public string[] RutaArchivos { get; set; }

        #endregion

        #region constructores

        public DatoCorreo()
        {

            this.Asunto = string.Empty;
            this.Origen = string.Empty;
            this.Destinatario = null;
            this.Cuerpo = string.Empty;
            this.EsHTML = false;
            this.EsSSL = false;
            this.Adjuntos = false;
            this.RutaArchivos = null;
        }

        #endregion
    }
}
