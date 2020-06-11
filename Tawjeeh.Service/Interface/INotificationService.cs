using System;
using System.Collections.Generic;
using Tawjeeh.Entities;

namespace Tawjeeh.Service.Interface
{
   public interface INotificationService
    {
        int CreateNotification(PushNotificationLogs notifications);
        int DeleteNotification(PushNotificationLogs notifications);
        int UpdateNotification(PushNotificationLogs notification);
        IList<PushNotificationLogs> GetAll();
        PushNotificationLogs GetNotificationById(long id);
        PushNotificationLogs GetNotificationByInitiativeCampaignId(long initiativeCampaignId);
    }
}
