using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tawjeeh.Service.Interface;
using Tawjeeh.Service.Service;
using Tawjeeh.SMSBulkSending.Notification;

namespace Tawjeeh.SMSBulkSending.InitiativeCampaign
{
    public class IocModule : NinjectModule
    {
        public override void Load()
        {            
            Bind<IInitiativeJobService>().To<InitiativeCampaignProcess>();
            //Bind<IPushNotification>().To<PushNotification>();
            //Bind<ICampaignService>().To<CampaignService>();
            //Bind<IInitiativeCampaignStatus>().To<InitiativeCampaignStatus>();
            //Bind<IInitiativeService>().To<InitiativeService>();
            //Bind<INotificationService>().To<NotificationService>();
        }
    }
}
