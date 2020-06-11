using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Filters;
using Tawjeeh.Api.Results;

namespace Tawjeeh.Api.Plugins
{
    public class EdartiAuthenticationAttribute : Attribute, IAuthenticationFilter
    {
        public bool AllowMultiple { get { return false; } }

        public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {

            bool isSet = false;
            var req = context.Request;
            AuthenticationHeaderValue authorization = req.Headers.Authorization;
            IEnumerable<string> headerValues;

            if (req.Headers.TryGetValues("TokenAuth", out headerValues))
            {
                isSet = Boolean.TryParse(headerValues.FirstOrDefault(), out isSet) ? isSet : false;
            }

            if (!isSet)
            {
                return Task.FromResult(0);
            }

            if (authorization != null && (string.Equals(authorization.Scheme, "Negotiate",
                StringComparison.OrdinalIgnoreCase)))
            {
                return Task.FromResult(0);
            }

            try
            {

                if (authorization != null &&
                  string.Equals(authorization.Scheme, "Bearer",
                    StringComparison.OrdinalIgnoreCase))
                {

                    if (string.IsNullOrEmpty(authorization.Parameter))
                    {
                        context.ErrorResult = new AuthenticationFailureResult("Forbidden", req);
                        return Task.FromResult(0);
                    }

                    var options = Startup.OAuthServerOptions;
                    AuthenticationTicket ticket = options.AccessTokenFormat.Unprotect(authorization.Parameter);

                    if ((ticket == null) ||
                     (ticket.Identity == null) ||
                     (!ticket.Identity.IsAuthenticated))
                    {
                        context.ErrorResult = new AuthenticationFailureResult("Forbidden", req);
                        return Task.FromResult(0);
                    }

                    DateTimeOffset currentUtc = options.SystemClock.UtcNow;

                    if (ticket.Properties.ExpiresUtc.HasValue &&
                        ticket.Properties.ExpiresUtc.Value < currentUtc)
                    {
                        context.ErrorResult = new AuthenticationFailureResult("Forbidden", req);
                        return Task.FromResult(0);
                    }

                    var principal = AuthenticateAsync(ticket, cancellationToken);

                    context.Principal = principal;

                }
                else
                {
                    context.ErrorResult = new AuthenticationFailureResult("Forbidden", req);
                    return Task.FromResult(0);
                }
            }
            catch (Exception ex)
            {
                context.ErrorResult = new AuthenticationFailureResult("Forbidden", req);
                return Task.FromResult(0);
            }

            return Task.FromResult(0);
        }

        private IPrincipal AuthenticateAsync(AuthenticationTicket ticket, CancellationToken cancellationToken1)
        {

            var claims = new List<Claim>()
            {
               new Claim(ClaimTypes.Name, ticket.Identity.Name),
            };
            var identity = new ClaimsIdentity(claims, "Token");
            return new ClaimsPrincipal(new[] { identity });
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            context.Result = new ResultWithChallenge(context.Result);
            return Task.FromResult(0);
        }


    }
    public class ResultWithChallenge : IHttpActionResult
    {
        private readonly IHttpActionResult next;
        public ResultWithChallenge(IHttpActionResult next)
        {
            this.next = next;
        }

        public async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = await next.ExecuteAsync(cancellationToken);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {

            }
            return response;
        }
    }
}