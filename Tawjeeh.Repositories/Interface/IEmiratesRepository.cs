using System.Collections.Generic;
using System.Threading.Tasks;
using Tawjeeh.Entities;

namespace Tawjeeh.Repositories.Interface
{
    public interface IEmiratesRepository
    {
        int CreateEmirates(Emirates emirates);
        int DeleteEmirates(Emirates emirates);
        int UpdateEmirates(Emirates emirates);
        Task<IEnumerable<Emirates>> GetAll();
        Emirates GetEmiratesById(int id);
    }
}
