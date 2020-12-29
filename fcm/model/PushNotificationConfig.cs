
namespace fcm.model
{
    public class PushNotificationConfig
    {
        #region propiedades

        public string FirebaseServerKeyToken { get; set; }
        public string FirebaseSenderID { get; set; }
        public string FirebaseURL { get; set; }
        
        #endregion

        #region constructores 

        public PushNotificationConfig()
        {
            FirebaseServerKeyToken = string.Empty;
            FirebaseSenderID = string.Empty;
            FirebaseURL = string.Empty;
        }

        #endregion
    }
}
