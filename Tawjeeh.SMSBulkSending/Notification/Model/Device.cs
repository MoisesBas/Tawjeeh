
namespace Tawjeeh.SMSBulkSending.Notification.Model
{
   public class Device
    {
        public string DeviceToken { get; set; }
        public string Message { get; set; }
        public string Priority { get; set; }
        public string Title { get; set; }
        public string InitiativeCampaignId { get; set; }

    }
}
