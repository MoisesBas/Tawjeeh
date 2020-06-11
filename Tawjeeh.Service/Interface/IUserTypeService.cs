using System.Collections.Generic;
using System.Threading.Tasks;
using Tawjeeh.Entities;

namespace Tawjeeh.Service.Interface
{
    public interface IUserTypeService
    {
        int CreateUserType(UserType userType);
        int DeleteUserType(UserType userType);
        int UpdateUserType(UserType userType);
        Task<IEnumerable<UserType>> GetAll();
        UserType GetUserTypeById(int id);
    }
}
