using Ninject;
using Ninject.Extensions.Interception;

namespace Tawjeeh.Infrastructure
{
   public class LogInterceptor: IInterceptor
    {
        [Inject]
        private ILogService _logService;
        public void Intercept(IInvocation invocation)
        {
            _logService = new LogService(invocation.Request.Target.GetType());
        }
    }
}
