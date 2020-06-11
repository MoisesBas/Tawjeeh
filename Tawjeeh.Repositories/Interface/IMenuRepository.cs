using System.Collections.Generic;
using System.Threading.Tasks;
using Tawjeeh.Entities;

namespace Tawjeeh.Repositories.Interface
{
    public interface IMenuRepository
    {
        int CreateMenu(Menu menu);
        int DeleteMenu(Menu menu);
        int UpdateMenu(Menu menu);
        Task<IEnumerable<Menu>> GetAll();
        Menu GetMenusById(int id);
    }
}
