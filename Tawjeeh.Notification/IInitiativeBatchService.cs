

using System.Collections.Generic;


namespace Tawjeeh.Notification
{   
    public interface IInitiativeBatchService
    {
        IList<Campaign> AddItemInInitiativeCampaigns();
        void ProcessCampaign(IList<Campaign> campaigns);
        bool SendNotification(PushNotificationLogs campaign);
        bool SendSMS(PushNotificationLogs campaign);
        bool SendEmail(PushNotificationLogs campaign);
    }
}
