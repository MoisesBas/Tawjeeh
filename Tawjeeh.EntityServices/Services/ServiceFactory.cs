
using Ninject;
using System;
using System.Linq;
using System.Reflection;
using Tawjeeh.EntityServices.Interface;


namespace Tawjeeh.EntityServices.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Ninject.Modules.NinjectModule" />
    /// <seealso cref="Tawjeeh.EntityServices.Interface.IServiceFactory" />
    public class ServiceFactory : Ninject.Modules.NinjectModule, IServiceFactory
    {
        /// <summary>
        /// The kernel
        /// </summary>
        IKernel _kernel;
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceFactory"/> class.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public ServiceFactory(IKernel kernel)
        {
            _kernel = kernel;
        }
        /// <summary>
        /// Gets the create article service.
        /// </summary>
        /// <value>
        /// The create article service.
        /// </value>
        public IArticleService CreateArticleService => _kernel.Get<IArticleService>();
        /// <summary>
        /// Gets the create laws service.
        /// </summary>
        /// <value>
        /// The create laws service.
        /// </value>
        public ILawsService CreateLawsService => _kernel.Get<ILawsService>();
        /// <summary>
        /// Gets the create user service.
        /// </summary>
        /// <value>
        /// The create user service.
        /// </value>
        public IUserService CreateUserService => _kernel.Get<IUserService>();
        /// <summary>
        /// Gets the create center service.
        /// </summary>
        /// <value>
        /// The create center service.
        /// </value>
        public ICenterService CreateCenterService => _kernel.Get<ICenterService>();
        /// <summary>
        /// Gets the create contact type service.
        /// </summary>
        /// <value>
        /// The create contact type service.
        /// </value>
        public IContactTypeService CreateContactTypeService => _kernel.Get<IContactTypeService>();
        /// <summary>
        /// Gets the create emirates service.
        /// </summary>
        /// <value>
        /// The create emirates service.
        /// </value>
        public IEmirateService CreateEmiratesService => _kernel.Get<IEmirateService>();
        /// <summary>
        /// Gets the create decision service.
        /// </summary>
        /// <value>
        /// The create decision service.
        /// </value>
        public IDecisionService CreateDecisionService => _kernel.Get<IDecisionService>();
        /// <summary>
        /// Gets the create utility service.
        /// </summary>
        /// <value>
        /// The create utility service.
        /// </value>
        public IUtilityService CreateUtilityService => _kernel.Get<IUtilityService>();
        /// <summary>
        /// Gets the create campaign service.
        /// </summary>
        /// <value>
        /// The create campaign service.
        /// </value>
        public ICampaignService CreateCampaignService => _kernel.Get<ICampaignService>();
        /// <summary>
        /// Gets the create initiative service.
        /// </summary>
        /// <value>
        /// The create initiative service.
        /// </value>
        public IInitiativeService CreateInitiativeService => _kernel.Get<IInitiativeService>();

        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            var assembly = Assembly.GetAssembly(typeof(ServiceFactory));
            var types = assembly.GetTypes().Where(x => x.IsClass && x.GetInterfaces().Any()).ToList();
            foreach (var type in types)
            {
                var interfaceType = type.GetInterfaces().FirstOrDefault();
                //_kernel.Bind(interfaceType).To(type).Intercept().With<LogInterceptor>();
                _kernel.Bind(interfaceType).To(type);
            }


        }
    }
}
