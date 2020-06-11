
using System;
using System.Collections.Generic;
using System.Linq;
using log4net;
using Tawjeeh.Entities;
using Tawjeeh.Infrastructure;
using Tawjeeh.Notification.Firebase;
using Tawjeeh.Service.Interface;
using static Tawjeeh.Entities.GlobalEnum;

namespace Tawjeeh.Notification
{
   public class InitiativeBatchService: JobServiceBase,
        IInitiativeBatchService
    {
        private ILog _logger = LogManager.GetLogger(typeof(InitiativeBatchService));
        private ICampaignService _campaignService;
        private INotificationService _notificationService;
        private IPushNotification _notification;
        public InitiativeBatchService(ICampaignService campaignService, 
            INotificationService notificationService,
            IPushNotification notification) : base()
        {
            Guard.NotNull(campaignService, nameof(campaignService));
            Guard.NotNull(notificationService, nameof(notificationService));
            Guard.NotNull(notification, nameof(notification));
                         _notificationService = notificationService;
                         _campaignService = campaignService;
                         _notification = notification;
        }

        public IList<Campaign> AddItemInInitiativeCampaigns() => _campaignService.GetCampaignAll();       

        public void ProcessCampaign(IList<Campaign> campaigns)
        {
            //log.Info(String.Format("Start Processing:{0}", campaigns.Count.ToString()));
            if (campaigns.Count > 0)
            {
                campaigns.ToList().ForEach(x => {

                    if (x.Initiative != null)
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
                                if (SendNotification(isExists))
                                    _notificationService.UpdateNotification(isExists);
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
                                if (SendNotification(push))
                                    _notificationService.CreateNotification(push);
                            }
                            // log.Info(String.Format("End Processing Campaign:{0}", y.Id));
                        });
                    }

                });
            }
        }

        public bool SendEmail(PushNotificationLogs campaign)
        {
            throw new System.NotImplementedException();
        }

        public bool SendNotification(PushNotificationLogs campaign)
        {
            return _notification.SendToSingle(campaign);
        }

        public bool SendSMS(PushNotificationLogs campaign)
        {
            throw new System.NotImplementedException();
        }

        protected override void Execute()
        {
            var result = AddItemInInitiativeCampaigns();
            if (result.Count > 0)
            {
                ProcessCampaign(result);
            }

        }
    }
}
