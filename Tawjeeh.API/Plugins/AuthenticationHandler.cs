using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Net.Http;
using System.Threading;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace Tawjeeh.Api.Plugins
{
    public class AuthenticationHandler : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(
           HttpRequestMessage request, CancellationToken cancellationToken)
        {
            IEnumerable<string> headerValues;
            AuthenticationHeaderValue authorization = request.Headers.Authorization;

            if (request.Headers.TryGetValues("TokenAuth", out headerValues))
            {
                bool isSet = Boolean.TryParse(headerValues.FirstOrDefault(), out isSet) ? isSet : false;

                if (isSet)
                {
                    if ((authorization == null) ||
                        (!string.Equals(authorization.Scheme, "Bearer", StringComparison.OrdinalIgnoreCase)) ||
                        (string.IsNullOrEmpty(authorization.Parameter)))
                    {
                        var response = new HttpResponseMessage(HttpStatusCode.Forbidden) { RequestMessage = request };
                        var tsc = new TaskCompletionSource<HttpResponseMessage>();
                        tsc.SetResult(response);
                        return await tsc.Task;

                    }
                    else
                    {
                        return await base.SendAsync(request, cancellationToken).ContinueWith<HttpResponseMessage>(
                            task => ApplyResponseHandler(task.Result));
                    }
                }
                else
                {
                    if ((authorization != null) && (string.Equals(authorization.Scheme, "Bearer", StringComparison.OrdinalIgnoreCase)))
                    {
                        var response = new HttpResponseMessage(HttpStatusCode.Forbidden) { RequestMessage = request };
                        var tsc = new TaskCompletionSource<HttpResponseMessage>();
                        tsc.SetResult(response);
                        return await tsc.Task;

                    }
                }
            }
            return await base.SendAsync(request, cancellationToken);
        }

        private HttpResponseMessage ApplyResponseHandler(
                   HttpResponseMessage response)
        {

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                response = new HttpResponseMessage(HttpStatusCode.Forbidden);
            }

            return response;
        }

    }

}