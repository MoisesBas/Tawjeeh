using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Tawjeeh.Api.Plugins
{

    public class EdartiAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            //if (actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<SpecialAuthorizeAttribute>().Any() || actionContext.ActionDescriptor.GetCustomAttributes<SpecialAuthorizeAttribute>().Any())
            //    return;


            base.OnAuthorization(actionContext);
        }
    }
}