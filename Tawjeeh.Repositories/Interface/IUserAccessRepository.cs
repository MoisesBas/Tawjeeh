using System.Collections.Generic;
using System.Threading.Tasks;
using Tawjeeh.Entities;

namespace Tawjeeh.Repositories.Interface
{
    public  interface IUserAccessRepository
    {
        int CreateUserAccess(MenuAccess access);
        int DeleteUserAccess(MenuAccess access);
        int UpdateUserAccess(MenuAccess access);
        Task<IEnumerable<MenuAccess>> GetAll();
        MenuAccess GetMenuAccessById(int id);
        Task<IEnumerable<MenuAccess>> GetMenuAccessByUserId(int userId);
        Task<IEnumerable<MenuAccess>> GetMenuAccessByMenuId(int menuId);
        int CreateBatchUserAccess(List<MenuAccess> access);
    }
}
