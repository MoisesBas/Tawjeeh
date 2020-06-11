using System;
using System.Linq;
using System.Collections.Generic;
using Tawjeeh.Entities;
using Tawjeeh.Service.Interface;
using Tawjeeh.Infrastructure;
using log4net;
using Tawjeeh.SMSBulkSending.Notification;
using static Tawjeeh.Entities.GlobalEnum;

namespace Tawjeeh.SMSBulkSending.InitiativeCampaign
{
    public class InitiativeCampaignStatus : IInitiativeCampaignStatus
    {
        //private static readonly ILog log = LogManager.GetLogger(typeof(InitiativeCampaignStatus));
        public int _count = 0;
        public IList<Campaign> _campaign;
        private ICampaignService _campaignService;
        private IInitiativeService _initiativeService;
        private IPushNotification _notification;
        private INotificationService _notificationService;
        public InitiativeCampaignStatus(ICampaignService campaignService,
            IInitiativeService initiativeService, 
            IPushNotification notification,
            INotificationService notificationService)
        {
            Guard.NotNull(campaignService, nameof(campaignService));
            Guard.NotNull(initiativeService, nameof(initiativeService));
            Guard.NotNull(notification, nameof(notification));
            Guard.NotNull(notificationService, nameof(notificationService));

            _campaignService = campaignService;
            _initiativeService = initiativeService;
            _notification = notification;
            _notificationService = notificationService;
        }
        public IList<Campaign> AddItemInInitiativeCampaigns() => _campaign = _campaignService.GetCampaignAll();
        public void ProcessCampaign(IList<Campaign> campaigns)
        {
            //log.Info(String.Format("Start Processing:{0}", campaigns.Count.ToString()));
            if (campaigns.Count > 0)
            {
                campaigns.ToList().ForEach(x => {

                    if(x.Initiative != null)
                    {
                        var runToday = x.Initiative.InitiativeCampaign.Where(dt => dt.StartDateTime.Value.Date.Equals(DateTime.Now.Date));
                        runToday.ToList().ForEach(y =>
                        {
                            //log.Info(String.Format("Start Processing Campaign:{0}", y.Id));
                            var isExists = _notificationService.GetNotificationByInitiativeCampaignId(Convert.ToInt32(y.Id));

                            if (isExists != null)
                            {
                                isExists.SendCnt = isExists.SendCnt + 1;
                                isExists.UpdatedBy = 1;
                                isExists.UpdatedOn = DateTime.Now;
                                if (SendNotification(isExists)) _notificationService.UpdateNotification(isExists);
                            }
                            else
                            {
                                PushNotificationLogs push = new PushNotificationLogs();
                                push.CreatedBy = 1;
                                push.CreatedOn = DateTime.Now;
                                push.InitiativeCampaignId = y.Id;
                                push.SendCnt = 1;
                                push.NotificationType = (int)NotificationType.PushNotification;
                                push.Topic = y.Description;
                                if (SendNotification(push)) _notificationService.CreateNotification(push);
                            }
                           // log.Info(String.Format("End Processing Campaign:{0}", y.Id));
                        });                        
                    } 
                    
                });                
            }
            //log.Info(String.Format("End Processing:{0}", campaigns.Count.ToString()));
        }

        public bool SendNotification(PushNotificationLogs notification) => _notification.SendToSingle(notification);
        public bool SendSMS(PushNotificationLogs notification)
        {
            throw new NotImplementedException();
        }

        public bool SendEmail(PushNotificationLogs notification)
        {
            throw new NotImplementedException();
        }
    }
}
