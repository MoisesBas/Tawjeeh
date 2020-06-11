using Microsoft.Owin.Security.Infrastructure;


namespace Tawjeeh.Api.Provider
{

    public class AccessTokenProvider : AuthenticationTokenProvider
    {
        public override async System.Threading.Tasks.Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            context.SetToken(context.SerializeTicket());
        }

        public override async System.Threading.Tasks.Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            context.DeserializeTicket(context.Token);
            context.OwinContext.Environment["Properties"] = context.Ticket.Properties;
        }

   
    }
    
}