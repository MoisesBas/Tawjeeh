using System;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Cors;
using System.Web.Http.Cors;

namespace Tawjeeh.Api.Plugins
{

    public class EdartiCorsPolicyAttribute : Attribute, ICorsPolicyProvider
    {
        private CorsPolicy _policy;
        private const string keyCorsAllowOrigin = "cors:allowOrigins";

        public EdartiCorsPolicyAttribute()
        {
            _policy = new CorsPolicy
            {
                AllowAnyMethod = true,
                AllowAnyHeader = true,
            };

            var whiteLists = ConfigurationManager.AppSettings[keyCorsAllowOrigin];

            if (!string.IsNullOrEmpty(whiteLists))
            {
                foreach (var origin in from v in whiteLists.Split(';')
                                       where !string.IsNullOrEmpty(v)
                                       select v)
                {
                    _policy.Origins.Add(origin.Trim());

                }
            }


        }

        public Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request,
           CancellationToken cancellationToken)
        {
            return Task.FromResult(_policy);
        }
    }



}