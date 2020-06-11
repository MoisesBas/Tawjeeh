

using Ninject;
using Ninject.Web.Common;
using Owin;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Tawjeeh.EntityFramework.Interface;
using Tawjeeh.EntityFramework.Repository;
using Tawjeeh.EntityServices.Interface;
using Tawjeeh.EntityServices.Services;
using Tawjeeh.Infrastructure;
using Tawjeeh.Infrastructure.SMS;

namespace Tawjeeh.Api
{
    public partial class Startup
    {
        public static IKernel ConfigureNinject(HttpConfiguration config)
        {                       
            return CreateKernel();
        }

        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                kernel.Bind(typeof(TawjeehContext)).ToSelf().InRequestScope();
                kernel.Bind(typeof(IRepositoryFactory)).To(typeof(RepositoryFactory)).InRequestScope();
                kernel.Bind(typeof(IServiceFactory)).To(typeof(ServiceFactory)).InRequestScope();
                kernel.Bind(typeof(ISms)).To(typeof(SMS)).InRequestScope();
                var repository = new List<Ninject.Modules.INinjectModule>{
                             new RepositoryFactory(kernel),
                             new ServiceFactory(kernel)
            };
                kernel.Load(repository);
            }
            catch(Exception ex)
            {
                kernel.Dispose();
                throw ex;
            }
            return kernel;
        }

    }
}