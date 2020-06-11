using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace Tawjeeh.Api.Plugins
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            string exceptionMessage = string.Empty;
            if (context.Exception.InnerException == null)
            {
                exceptionMessage = context.Exception.Message;
                Elmah.ErrorLog.GetDefault(HttpContext.Current).Log(new Elmah.Error(context.Exception));
            }
            else
            {
                exceptionMessage = context.Exception.InnerException.Message;
                Elmah.ErrorLog.GetDefault(HttpContext.Current).Log(new Elmah.Error(context.Exception.InnerException));
            }         
            
            var response = new System.Net.Http.HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("An Unhandled exception was thrown by Web API."),  
                    ReasonPhrase = "Internal Server Error.Please Contact your Administrator."
            };
           
            context.Response = response;
           
        }
    }
}