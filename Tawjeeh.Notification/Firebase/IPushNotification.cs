using System.Collections.Generic;


namespace Tawjeeh.Notification.Firebase
{
    public interface IPushNotification
    {
        bool SendToSingle(PushNotificationLogs fcmdevice);
        bool SendToMultiple(List<PushNotificationLogs> fcmdevices);
    }
}
