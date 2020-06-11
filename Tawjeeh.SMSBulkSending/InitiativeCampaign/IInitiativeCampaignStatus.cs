using System.Collections.Generic;
using Tawjeeh.Entities;

namespace Tawjeeh.SMSBulkSending.InitiativeCampaign
{
    public interface IInitiativeCampaignStatus
    {
        IList<Campaign> AddItemInInitiativeCampaigns();
        void ProcessCampaign(IList<Campaign> campaigns);
        bool SendNotification(PushNotificationLogs campaign);
        bool SendSMS(PushNotificationLogs campaign);
        bool SendEmail(PushNotificationLogs campaign);
    }
}
