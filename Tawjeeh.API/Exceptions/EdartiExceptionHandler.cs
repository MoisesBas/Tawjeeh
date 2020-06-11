using Tawjeeh.Api.Results;
using Newtonsoft.Json;
using System.Web.Http.ExceptionHandling;

namespace Tawjeeh.Api.Exceptions
{
    public class EdartiExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {

            var exception = new 
            {
                Source = context.Exception.Source,
                Message = context.Exception.Message
            };

            string exceptionString = JsonConvert.SerializeObject(exception);
            context.Result = new EdartiErrorResult
            {
                Request = context.Request,

                Content = exceptionString.ToString()// "An internal server error occurred; check the log for more information!"
            };
        }


    }
}