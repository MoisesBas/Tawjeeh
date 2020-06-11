//using Elmah.Contrib.WebApi;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Tawjeeh.Api.Exceptions;
using Tawjeeh.Api.Plugins;

namespace Tawjeeh.Api
{
    public partial class Startup
    {
        public static void ConfigureWebApi(HttpConfiguration config)
        {

            var corsAttr = new EdartiCorsPolicyAttribute();
            config.EnableCors(corsAttr);
            config.Services.Add(typeof(IExceptionLogger), new EdartiExceptionLogger());
            config.Services.Replace(typeof(IExceptionHandler), new EdartiExceptionHandler());          
            config.Filters.Add(new ExceptionFilter());         
            config.Filters.Add(new HostAuthenticationFilter(Startup.OAuthServerOptions.AuthenticationType));
            config.Filters.Add(new EdartiAuthenticationAttribute());
            config.Filters.Add(new AuthorizeAttribute());
            var settings = new JsonSerializerSettings();
            settings.PreserveReferencesHandling = PreserveReferencesHandling.None;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.SerializerSettings = settings;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.MessageHandlers.Add(new AuthenticationHandler());
            config.MessageHandlers.Add(new CancelledTaskBugWorkaroundMessageHandler());

            config.MapHttpAttributeRoutes();
        }

    }
}
