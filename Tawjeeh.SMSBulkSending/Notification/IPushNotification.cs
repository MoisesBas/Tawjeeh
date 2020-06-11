using System.Collections.Generic;
using Tawjeeh.Entities;

namespace Tawjeeh.SMSBulkSending.Notification
{
    public interface IPushNotification
    {
        bool SendToSingle(PushNotificationLogs fcmdevice);
        bool SendToMultiple(List<PushNotificationLogs> fcmdevices);      
    }
}
