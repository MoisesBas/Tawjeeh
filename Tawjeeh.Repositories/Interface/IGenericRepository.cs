using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tawjeeh.Repositories.Interface
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IList<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();
        int Create(TEntity entity);
        int Delete(TEntity entity);
        int Update(TEntity entity);
        

    }
}
