using System.IO;
//using log4net.Config;
using System.Configuration;
using Topshelf;
using log4net.Config;
using Ninject;
using Tawjeeh.Service.Interface;
using Tawjeeh.Notification.Firebase;

namespace Tawjeeh.Notification
{
   public class Program
    {
        static void Main(string[] args)
        {          
            var logCfg = new FileInfo(System.AppDomain.CurrentDomain.BaseDirectory + "log4net.config");
            XmlConfigurator.ConfigureAndWatch(logCfg);                    

            Topshelf.HostFactory.Run(x =>
            {               
                IKernel kernel = new StandardKernel(new IOCModule());
                x.UseLog4Net();
                x.Service<IJobService>(s =>
                {         
                    s.ConstructUsing(name=> new InitiativeBatchService( 
                        kernel.Get<ICampaignService>(),
                        kernel.Get<INotificationService>(),
                        kernel.Get<IPushNotification>())); 
                    
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();
                x.SetDescription("testing");
                x.SetDisplayName("testing");
                x.SetServiceName("testing");

            });
        }
    }
}
