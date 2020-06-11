using System.Linq;
namespace Tawjeeh.EntityFramework.Helper
{
    public interface IQuery<T>
    {        IQueryable<T> Filter(IQueryable<T> items);
    }
}
