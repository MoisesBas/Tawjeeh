using Ninject.Modules;
using Tawjeeh.Infrastructure;
using Tawjeeh.Notification.Firebase;
using Tawjeeh.Repositories.Interface;
using Tawjeeh.Repositories.Repository;
using Tawjeeh.Service.Interface;
using Tawjeeh.Service.Service;

namespace Tawjeeh.Notification
{
    public class IOCModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IJobService>().To<JobServiceBase>().InSingletonScope();           
            Bind<IConnectionFactory>().To<ConnectionFactory>().InTransientScope();
            Bind<ICampaignDetailsRepository>().To<CampaignDetailsRepository>().InSingletonScope();
            Bind<IGoalRepository>().To<GoalRepositorycs>().InSingletonScope();
            Bind<ICampaignDocumentRepository>().To<CampaignDocumentRepository>();
            Bind<ICampaignRepository>().To<CampaignRepository>().InSingletonScope();
            Bind<ICampaignService>().To<CampaignService>().InSingletonScope();
            Bind<INotificationService>().To<NotificationService>().InSingletonScope();
            Bind<INotificationRepository>().To<NotificationRepository>().InSingletonScope();
            Bind<IPushNotification>().To<PushNotification>().InSingletonScope();
            Bind<IInitiativeBatchService>().To<InitiativeBatchService>().InTransientScope();
        }
    }
}
