using System.Web.Http.Filters;

namespace Tawjeeh.Api.Plugins
{
    public class AddMiniProfilerCORSHeaderFilter : ActionFilterAttribute
{
    public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
    {
        actionExecutedContext.Response.Headers.Add("Access-Control-Expose-Headers", "X-MiniProfiler-Ids");
    }
}
   
}