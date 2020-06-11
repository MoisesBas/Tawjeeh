using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tawjeeh.Entities;

namespace Tawjeeh.Repositories.Interface
{
  public  interface INotificationRepository
    {
        int CreateNotification(PushNotificationLogs notifications);
        int DeleteNotification(PushNotificationLogs notifications);
        int UpdateNotification(PushNotificationLogs notification);
        IList<PushNotificationLogs> GetAll();
        PushNotificationLogs GetNotificationById(long id);
        PushNotificationLogs GetNotificationByInitiativeCampaignId(long initiativeCampaignId);
    }
}
