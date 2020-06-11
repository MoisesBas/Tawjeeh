using log4net;
using log4net.Config;
using System;
using Tawjeeh.SMSBulkSending.Testing;
using Topshelf;
using Topshelf.Ninject;

namespace Tawjeeh.SMSBulkSending
{
    public class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));
        static void Main(string[] args)
        {


            XmlConfigurator.Configure();


            log.Info("Update Campaign Status Service Started" + DateTime.Now.TimeOfDay);

            HostFactory.Run(x =>
            {

                x.UseNinject(new SampleModule());
                x.UseLog4Net();
                x.Service<SampleService>(s =>
                {
                    s.ConstructUsingNinject();
                    s.WhenStarted((service, control) => service.Start());
                    s.WhenStopped((service, control) => service.Stop());
                });
                x.RunAsLocalSystem();
                x.EnableServiceRecovery(service =>
                {
                    service.RestartService(1);
                    service.OnCrashOnly();
                });
                x.SetDescription("Process initiative for campaign");
                x.SetDisplayName("Initiative Campaign Service");
                x.SetServiceName("Initiative Campaign Service");
            });

            //HostFactory.Run(x =>
            //{

            //    x.UseNinject(new NinjectModuleJobService());
            //    x.UseLog4Net();
            //    x.Service<JobService>(s =>
            //    {
            //        s.ConstructUsingNinject();
            //        s.WhenStarted((service, control) => service.Start());
            //        s.WhenStopped((service, control) => service.Stop());
            //    });
            //    x.RunAsLocalSystem();
            //    //x.EnableServiceRecovery(service =>
            //    //{
            //    //    service.RestartService(1);
            //    //    service.OnCrashOnly();
            //    //});
            //    //x.SetDescription("Process initiative for campaign");
            //    //x.SetDisplayName("Initiative Campaign Service");
            //    //x.SetServiceName("Initiative Campaign Service");
            //});
            //log.Info("Stop the service");
        }
    }
}
