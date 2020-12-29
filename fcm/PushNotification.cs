using fcm.model;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace fcm
{
    public class PushNotification : IPushNotification
    {
        #region variables

        private string Message;
        private PushNotificationConfig config;

        #endregion

        #region constructores

        public PushNotification()
        {
            Message = string.Empty;
        }

        #endregion

        #region métodos implementados

        /// <summary>
        /// Leer el mensaje de clase 
        /// </summary>
        /// <returns>Mensaje generado por la clase</returns>
        public string GetMessage() {
            return Message;
        }

        /// <summary>
        /// Establecer los parámetros de configuración para el envío
        /// </summary>
        /// <param name="pushNotificationConfig">Objeto con los parámetros</param>
        public void SetFirebaseConfig(PushNotificationConfig pushNotificationConfig)
        {
            config = pushNotificationConfig;
        }

        /// <summary>
        /// Enviar notificación push
        /// </summary>
        /// <param name="deviceId">Identificador del dispositivo</param>
        /// <param name="notificationItem">Objeto con los datos de la notificación</param>
        /// <returns></returns>
        public string SendPushNotification(string deviceId, PushNotificationItem notificationItem)
        {
            try {
                WebRequest tRequest;
                tRequest = WebRequest.Create(config.FirebaseURL);
                tRequest.Method = "post";
                tRequest.ContentType = " application/json";

                tRequest.Headers.Add(string.Format("Authorization: key={0}", config.FirebaseServerKeyToken));
                tRequest.Headers.Add(string.Format("Sender: id={0}", config.FirebaseSenderID));

                var a = new
                {
                    notification = new
                    {
                        title = notificationItem.Title,
                        body = notificationItem.Body,
                        icon = notificationItem.Icon,
                        notificationItem.ClickAction,
                        sound = "mySound"
                    },
                    to = deviceId
                };

                byte[] byteArray = Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(a));
                tRequest.ContentLength = byteArray.Length;

                Stream dataStream = tRequest.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                WebResponse tResponse = tRequest.GetResponse();
                dataStream = tResponse.GetResponseStream();

                StreamReader tReader = new StreamReader(dataStream);
                string sResponseFromServer = tReader.ReadToEnd();

                tReader.Close();
                dataStream.Close();
                tResponse.Close();

                return sResponseFromServer;
            }
            catch(Exception ex)
            {
                Message = "Error al enviar la notificación | " + ex.Message;
                return "Error";
            }
        }

        #endregion
    }
}
