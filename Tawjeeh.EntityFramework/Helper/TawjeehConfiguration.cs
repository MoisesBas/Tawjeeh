using System.Data.Entity;

namespace Tawjeeh.EntityFramework.Helper
{
    public class TawjeehConfiguration : DbConfiguration
    {
        public TawjeehConfiguration()
        {
            AddInterceptor(new SoftDeleteInterceptor());
            AddInterceptor(new CreatedAndModifiedDateInterceptor());            
        }
    }
}
