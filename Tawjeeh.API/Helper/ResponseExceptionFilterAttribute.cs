using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace Tawjeeh.Api.Helper
{
    public class ResponseExceptionFilterAttribute : ExceptionFilterAttribute, IExceptionFilter
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {         

            if (actionExecutedContext.Exception is ResponseException)
            {                
                var res = actionExecutedContext.Exception.Message;               
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(res),
                    ReasonPhrase = res
                };          

                actionExecutedContext.Response = response;
            }
        }
    }
}