using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Tawjeeh.Api.Provider
{
    public interface IIdentityProvider
    {
        IPrincipal GetPrincipal();
    }
}
