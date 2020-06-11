using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Cors;
using Tawjeeh.Api.Provider;

namespace Tawjeeh.Api
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthServerOptions { get; private set; }
        static Startup()
        {
            OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/account/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(365),
                Provider = new EdartiAuthorizationServerProvider(),
                AccessTokenProvider = new AccessTokenProvider()
            };
        }

        public static void ConfigureAuth(IAppBuilder app)
        {          
           

            var policy = new CorsPolicy
            {
                AllowAnyHeader = true,
                AllowAnyMethod = true,
                AllowAnyOrigin = true,
                SupportsCredentials = false,
                PreflightMaxAge = Int32.MaxValue
            };
            app.UseCors(CorsOptions.AllowAll);           
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions
            {
                AccessTokenFormat = OAuthServerOptions.AccessTokenFormat,
                AccessTokenProvider = OAuthServerOptions.AccessTokenProvider,
            });
        }
    }



}