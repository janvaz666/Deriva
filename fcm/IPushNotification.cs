using fcm.model;

namespace fcm
{
    public interface IPushNotification
    {
        string GetMessage();
        void SetFirebaseConfig(PushNotificationConfig pushNotificationConfig);
        string SendPushNotification(string deviceId, PushNotificationItem notificationItem);
    }
}
