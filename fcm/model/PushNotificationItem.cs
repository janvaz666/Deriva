
namespace fcm.model
{
    public class PushNotificationItem
    {
        #region propiedades

        public string Title { get; set; }
        public string Body { get; set; }
        public string Icon { get; set; }
        public string ClickAction { get; set; }

        #endregion

        #region cosntructores

        public PushNotificationItem()
        {
            Title = string.Empty;
            Body = string.Empty;
            Icon = string.Empty;
            ClickAction = string.Empty;
        }

        #endregion
    }
}
