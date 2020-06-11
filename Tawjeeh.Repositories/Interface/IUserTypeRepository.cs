using System.Collections.Generic;
using System.Threading.Tasks;
using Tawjeeh.Entities;

namespace Tawjeeh.Repositories.Interface
{
   public interface IUserTypeRepository
    {
        int CreateUserType(UserType userType);
        int DeleteUserType(UserType userType);
        int UpdateUserType(UserType userType);
        Task<IEnumerable<UserType>> GetAll();
        UserType GetUserTypeById(int id);
    }
}
