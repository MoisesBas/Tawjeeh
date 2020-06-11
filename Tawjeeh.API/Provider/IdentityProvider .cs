using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Tawjeeh.Api.Provider
{
    public class IdentityProvider : IIdentityProvider
    {
        public IPrincipal GetPrincipal()
        {
            return HttpContext.Current.User;
        }       
    }
}