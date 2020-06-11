using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Tawjeeh.EntityServices.Interface;
using Tawjeeh.Infrastructure;

namespace Tawjeeh.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class BaseController: ApiController
    {
        /// <summary>
        /// The service factory
        /// </summary>
        public IServiceFactory _serviceFactory;
        /// <summary>
        /// The SMS
        /// </summary>
        public ISms _sms;
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController"/> class.
        /// </summary>
        /// <param name="serviceFactory">The service factory.</param>
        /// <param name="sms">The SMS.</param>
        public BaseController(IServiceFactory serviceFactory, ISms sms)
        {
            Guard.NotNull(serviceFactory, nameof(serviceFactory));
            _serviceFactory = serviceFactory;
            _sms = sms;
        }
    }
}