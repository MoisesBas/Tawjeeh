using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using Tawjeeh.EntityServices.Interface;
using Tawjeeh.Api.Plugins;
using Tawjeeh.Infrastructure;

namespace Tawjeeh.Api.Provider
{
    public class EdartiAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {        
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var createservice = new NinjectResolver(Startup.CreateKernel());
            var service = createservice.GetService<IUserService>();
            var password = Utilities.Encrypt(context.Password);
            var User = service.GetUserbyCredential(context.UserName, password).Result;

            if (User == null)
            {
                context.SetError("Error", "Provided credentials are not valid");
                context.Rejected();
                return;
            }
            else
            {
                ClaimsIdentity identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity = new ClaimsIdentity(Startup.OAuthServerOptions.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));

                var props = new AuthenticationProperties(new Dictionary<string, string>
            {
                {
                    "Id", User.Id.ToString()
                },
                {
                    "userTypeId", User.UserTypeId.ToString()
                },
                {
                    "fullName", User.FullName.ToString()
                },
                {
                    "email", User.Email.ToString()
                },

            });

                var ticket = new AuthenticationTicket(identity, props);

                context.Validated(ticket);
            }

        }
        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            Uri uri;
            if (Uri.TryCreate(context.RedirectUri, UriKind.Absolute, out uri))
            {
                context.Validated();

                return Task.FromResult(0);
            }
            return base.ValidateClientRedirectUri(context);
        }
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

    }
}