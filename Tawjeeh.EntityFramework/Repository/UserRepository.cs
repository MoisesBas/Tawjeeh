using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tawjeeh.EntityFramework.Helper;
using Tawjeeh.EntityFramework.Interface;
using Tawjeeh.EntityModel;

namespace Tawjeeh.EntityFramework.Repository
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Tawjeeh.EntityFramework.Repository.RepositoryBase{Tawjeeh.EntityFramework.Repository.TawjeehContext}" />
    /// <seealso cref="Tawjeeh.EntityFramework.Interface.IUserRepository{Tawjeeh.EntityModel.User}" />
    public class UserRepository : RepositoryBase<TawjeehContext>,
        IUserRepository<User>
    {
        /// <summary>
        /// Inserts the or update user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public int InsertOrUpdateUser(User user) => InsertOrUpdate(user);
        /// <summary>
        /// Deletes the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public int Delete(User user) => DeleteRecord(user);
        /// <summary>
        /// Gets all user.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<User>> GetAllUser()
        {
            return GetListDisposableContextAsync<User>();
        }

        /// <summary>
        /// Gets the type of all user by user.
        /// </summary>
        /// <param name="userTypeId">The user type identifier.</param>
        /// <returns></returns>
        public IEnumerable<User> GetAllUserByUserType(long? userTypeId)
        {
            var userSearch = Query<User>.Create(x=> x.UserTypeId == userTypeId);
            return GetAllQuery(userSearch).ToList();            
        }

        /// <summary>
        /// Gets the userby credential.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public Task<User> GetUserbyCredential(string userName, string password)
        {
            var userSearch = Query<User>.Create(x => x.UserName.Equals(userName)
                                       && x.Password.Equals(password));
            
            return FirstOrDefaultDisposableAsync(userSearch);
        }

        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public User GetUserById(long id)
        {
            var userSearch = Query<User>.Create(x => x.Id == id);
            return FirstOrDefault(userSearch);
        }

        /// <summary>
        /// Gets the user by user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public IEnumerable<User> GetUserByUserId(long[] userId)
        {
            var userSearch = Query<User>.Create(x=>userId.Contains(x.Id));
            return GetAllQuery(userSearch).ToList();
        }

        /// <summary>
        /// Determines whether [is user exist] [the specified user name].
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        public User IsUserExist(string userName)
        {
            var userSearch = Query<User>.Create(x => x.UserName.Equals(userName));
            return FirstOrDefault(userSearch);
        }
        /// <summary>
        /// Determines whether [is mobile user] [the specified user name].
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        public User IsMobileUser(string userName)
        {
            var userSearch = Query<User>.Create(x => x.MobileNo.Equals(userName));
            return FirstOrDefault(userSearch);
        }
        /// <summary>
        /// Determines whether [is user exist] [the specified user name].
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="mobileNo">The mobile no.</param>
        /// <returns></returns>
        public User IsUserExist(string userName, string mobileNo)
        {
            var userSearch = Query<User>.Create(x => x.UserName.Equals(userName)
                                             && x.MobileNo.Equals(mobileNo));
            return FirstOrDefault(userSearch);
        }

        /// <summary>
        /// Logins the specified user name.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Login(string userName, string password)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Registers the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public int RegisterUser(User user)
        {
            return InsertOrUpdate(user);
        }

        /// <summary>
        /// Mobiles the login.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public User MobileLogin(string userName, string password)
        {
            var userSearch = Query<User>.Create(x => x.UserName.Equals(userName)
                                      && x.Password.Equals(password));
            return FirstOrDefaultDisposable(userSearch);
        }

    }
}
