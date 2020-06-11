using log4net;
using System;
using System.Collections.Generic;
using Tawjeeh.Entities;
using Tawjeeh.Infrastructure;
using Tawjeeh.Repositories.Interface;
using Tawjeeh.Service.Interface;

namespace Tawjeeh.Service.Service
{
    public class NotificationService : INotificationService
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(NotificationService));       
        private INotificationRepository _repoNotification;

        public NotificationService(INotificationRepository repoNotification)
        {
            Guard.NotNull(repoNotification, nameof(repoNotification));
            _repoNotification = repoNotification;
       
        }
        public int CreateNotification(PushNotificationLogs notifications)
        {
            return _repoNotification.CreateNotification(notifications);
        }

        public int DeleteNotification(PushNotificationLogs notifications)
        {
            return _repoNotification.DeleteNotification(notifications);
        }

        public IList<PushNotificationLogs> GetAll()
        {
            return _repoNotification.GetAll();
        }

        public PushNotificationLogs GetNotificationById(long id)
        {
            return _repoNotification.GetNotificationById(id);
        }

        public PushNotificationLogs GetNotificationByInitiativeCampaignId(long initiativeCampaignId)
        {
            return _repoNotification.GetNotificationByInitiativeCampaignId(initiativeCampaignId);
        }

        public int UpdateNotification(PushNotificationLogs notification)
        {
            return _repoNotification.UpdateNotification(notification);
        }
    }
}
