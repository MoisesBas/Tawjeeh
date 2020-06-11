using Dapper;
using System;
using System.Linq;
using Tawjeeh.Entities;
using Tawjeeh.Infrastructure;
using Tawjeeh.Repositories.Interface;

namespace Tawjeeh.Repositories.Repository
{
    public class NotificationRepository: BaseRepository<PushNotificationLogs>, 
        INotificationRepository
    {
        public NotificationRepository(IConnectionFactory connectionFactory)
           : base(connectionFactory)
        {
        }
        public int CreateNotification(PushNotificationLogs notifications)
        {
            notifications.IsActive = true;
            notifications.IsDeleted = false;
            notifications.CreatedOn = DateTime.Now;
            return base.Create(notifications);
        }

        public int DeleteNotification(PushNotificationLogs notifications)
        {
            notifications.IsActive = true;
            notifications.IsDeleted = true;
            notifications.UpdatedOn = DateTime.Now;
            return base.Update(notifications);          
        }
        public PushNotificationLogs GetNotificationById(long id)
        {
            using (var _conn = _connectionFactory.GetConnection)
            {
                var query = "SELECT * FROM tblPushNotificationLogs WHERE Id=@id and IsDeleted=0";
                var result = _conn.Query<PushNotificationLogs>(query, new { @id = id });
                return result.FirstOrDefault();
            }           
        }

        public PushNotificationLogs GetNotificationByInitiativeCampaignId(long initiativeCampaignId)
        {
            using (var _conn = _connectionFactory.GetConnection)
            {
                var query = "SELECT * FROM tblPushNotificationLogs WHERE InitiativeCampaignId=@id and IsDeleted=0";
                var result = _conn.Query<PushNotificationLogs>(query, new { @id = initiativeCampaignId });
                return result.FirstOrDefault();
            }
        }
        public int UpdateNotification(PushNotificationLogs notification)
        {
            notification.IsActive = true;
            notification.IsDeleted = true;
            notification.UpdatedOn = DateTime.Now;
            return base.Update(notification);
        }

    }
}
