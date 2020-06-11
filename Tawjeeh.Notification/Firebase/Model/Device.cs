using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tawjeeh.Notification.Firebase.Model
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
