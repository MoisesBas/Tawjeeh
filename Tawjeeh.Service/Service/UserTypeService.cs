using System.Collections.Generic;
using System.Threading.Tasks;
using Tawjeeh.Entities;
using Tawjeeh.Infrastructure;
using Tawjeeh.Repositories.Interface;
using Tawjeeh.Service.Interface;

namespace Tawjeeh.Service.Service
{

    public class UserTypeService : IUserTypeService
    {
        private IUserTypeRepository _userTypeRepo;
        public UserTypeService(IUserTypeRepository userTypeRepo)
        {
            Guard.NotNull(userTypeRepo, nameof(userTypeRepo));
            _userTypeRepo = userTypeRepo;
        }

        public int CreateUserType(UserType userType)
        {
            return _userTypeRepo.CreateUserType(userType);
        }

        public int DeleteUserType(UserType userType)
        {
            return _userTypeRepo.DeleteUserType(userType);
        }

        public Task<IEnumerable<UserType>> GetAll()
        {
            return _userTypeRepo.GetAll();
        }

        public UserType GetUserTypeById(int id)
        {
            return _userTypeRepo.GetUserTypeById(id);
        }

        public int UpdateUserType(UserType userType)
        {
            return _userTypeRepo.UpdateUserType(userType);
        }
    }
}
