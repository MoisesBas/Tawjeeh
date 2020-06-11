using System;
using System.Collections.Generic;
using System.Transactions;
using System.Linq;
using System.Threading.Tasks;
using Tawjeeh.EntityFramework.Interface;
using Tawjeeh.EntityModel;
using Tawjeeh.EntityModel.Password;
using Tawjeeh.EntityServices.Interface;
using Tawjeeh.Infrastructure;
using System.IO;
using System.Security.AccessControl;

namespace Tawjeeh.EntityServices.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Tawjeeh.EntityServices.Interface.IUserService" />
    public class UserService : IUserService
    {
        /// <summary>
        /// The repository factory
        /// </summary>
        private IRepositoryFactory _repositoryFactory;
        /// <summary>
        /// The helper
        /// </summary>
        private IHelper _helper;
        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="repositoryFactory">The repository factory.</param>
        /// <param name="helper">The helper.</param>
        public UserService(IRepositoryFactory repositoryFactory, IHelper helper)
        {
            Guard.NotNull(repositoryFactory, nameof(repositoryFactory));
            Guard.NotNull(helper, nameof(helper));

            _repositoryFactory = repositoryFactory;
            _helper = helper;
        }
        /// <summary>
        /// Adds the user to center.
        /// </summary>
        /// <param name="users">The users.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int AddUserToCenter(User users)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Deletes the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Users is not exists</exception>
        public int Delete(User user)
        {
            var users = _repositoryFactory.GetUserRepository.GetUserById(user.Id);
            if (users == null) throw new Exception("Users is not exists");
            return _repositoryFactory.GetUserRepository.Delete(users);
        }
        /// <summary>
        /// Gets all user.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<User>> GetAllUser()
        {
            return _repositoryFactory.GetUserRepository.GetAllUser();
        }
        /// <summary>
        /// Gets the type of all user by user.
        /// </summary>
        /// <param name="userTypeId">The user type identifier.</param>
        /// <returns></returns>
        public IEnumerable<User> GetAllUserByUserType(long userTypeId)
        {
            return _repositoryFactory.GetUserRepository.GetAllUserByUserType(userTypeId);
        }
        /// <summary>
        /// Gets the userby credential.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public Task<User> GetUserbyCredential(string userName, string password)
            => _repositoryFactory.GetUserRepository.GetUserbyCredential(userName, password);
        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public User GetUserById(int id)
        {
            return _repositoryFactory.GetUserRepository.GetUserById(id);
        }
        /// <summary>
        /// Resets the confirm password.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public int ResetConfirmPassword(User user)
        {    
              return _repositoryFactory.GetUserRepository.InsertOrUpdateUser(user);            
        }
        /// <summary>
        /// Inserts the or update.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Mobile Number Should 12 digit., ex. 971500000000</exception>
        public int InsertOrUpdate(User user)
        {
            int output = 0;

            if(user.Id == 0)
            {
                var passSettings = new PasswordSettings();
                if (user.MobileNo.Length < 7) throw new Exception("Mobile Number Should 12 digit., ex. 971500000000");
                var password = user.MobileNo.Substring(user.MobileNo.Length - 7);
                user.Password = Utilities.Encrypt(password);
                user.UserName = string.IsNullOrEmpty(user.UserName) ? user.Email : user.UserName;              
                output = _repositoryFactory.GetUserRepository.InsertOrUpdateUser(user);                
            }
            else
            {
                var result = _repositoryFactory.GetUserRepository.GetUserById(user.Id);
                user.Password = result.Password;

                output = _repositoryFactory.GetUserRepository.InsertOrUpdateUser(user);

            }
            return output;
        }
        /// <summary>
        /// Determines whether [is mobile user] [the specified user name].
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        public User IsMobileUser(string userName)
        {
            return _repositoryFactory.GetUserRepository.IsMobileUser(userName);
        }
        /// <summary>
        /// Determines whether [is user exist] [the specified user name].
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        public User IsUserExist(string userName)
        {
           return  _repositoryFactory.GetUserRepository.IsUserExist(userName);
        }
        /// <summary>
        /// Determines whether [is user exist] [the specified user name].
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="mobileNo">The mobile no.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public User IsUserExist(string userName, string mobileNo)
        {
            throw new NotImplementedException();
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
        /// Mobiles the login.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public User MobileLogin(string userName, string password)
        {
            password = Utilities.Encrypt(password);
            return _repositoryFactory.GetUserRepository.MobileLogin(userName, password);
        }
        /// <summary>
        /// Mobiles the request otp.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public User MobileRequestOTP(User user)
        {
            var userProfile = new User();
            user.IsOTP = false;
            user.OTP = Utilities.GenerateOTP(false, false,
                true, false, false, 4);

            var output = _repositoryFactory.GetUserRepository.InsertOrUpdateUser(user);
            if (output > 0)
            {
                _helper.UserRegistrationNotificationForSendOTMobileUser(user.MobileNo, user.OTP);
                userProfile = _repositoryFactory.GetUserRepository.GetUserById(user.Id);
                userProfile.Password = string.Empty;
                userProfile.OTP = string.Empty;                
            }
            return userProfile;
        }
        /// <summary>
        /// Registers the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public User RegisterUser(User user)
        {
            var userProfile = new User();
            user.UserName = string.IsNullOrEmpty(user.UserName) ? user.Email : user.UserName;

            var passSettings = new EntityModel.Password.PasswordSettings();
            user.Password = Utilities.Encrypt(user.Password);
            user.IsOTP = false;
            user.OTP = Utilities.GenerateOTP(false, false,
                true, false, false, 4);

            var output = _repositoryFactory.GetUserRepository.RegisterUser(user);
            if (output > 0)
            {
                _helper.UserRegistrationNotificationForSendOTMobileUser(user.MobileNo, user.OTP);
                userProfile = _repositoryFactory.GetUserRepository.GetUserById(output);
                userProfile.Password = string.Empty;
                userProfile.OTP = string.Empty;
                
            }
            return userProfile;
        }
        /// <summary>
        /// Resends the otp.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        /// <exception cref="Exception">User is not exists.,</exception>
        public User ResendOTP(User user)
        {
            var userProfile = new User();
            using (var transaction = new TransactionScope())
            {
                var passSettings = new PasswordSettings();
                user = _repositoryFactory.GetUserRepository.IsUserExist(user.Email, user.MobileNo);

                if (user == null)
                    throw new Exception("User is not exists.,");

                user.IsOTP = false;
                user.OTP = Utilities.GenerateOTP(false, false,
                    true, false, false, 4);

                var output = _repositoryFactory.GetUserRepository.InsertOrUpdateUser(user);
                if (output > 0)
                {
                    _helper.UserRegistrationNotificationForSendOTMobileUser(user.MobileNo, user.OTP);
                    userProfile = _repositoryFactory.GetUserRepository.GetUserById(user.Id);
                    userProfile.Password = string.Empty;
                    userProfile.OTP = string.Empty;
                    transaction.Complete();
                    transaction.Dispose();
                }
            }
            return userProfile;
        }
        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public User ResetPassword(User user)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Updates the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int Update(User user)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Verifies the otp.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        /// <exception cref="Exception">
        /// User is not exists.,
        /// or
        /// OTP does not match.,
        /// </exception>
        public User VerifyOTP(User user)
        {
            var passSettings = new PasswordSettings();
            var newOTP = user.OTP;
            user = _repositoryFactory.GetUserRepository.IsUserExist(user.Email, user.MobileNo);

            if (user == null)
                throw new Exception("User is not exists.,");

            if (user.OTP == newOTP)
            {
                user.IsOTP = true;
               _repositoryFactory.GetUserRepository.InsertOrUpdateUser(user);               
            }
            else
            {
                throw new Exception("OTP does not match.,");
            }
            return user;
        }
        /// <summary>
        /// Forgots the password.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public bool ForgotPassword(User user)
        {
            bool result = false;
            try
            {
                user.IsOTP = true;
                var output = _repositoryFactory.GetUserRepository.InsertOrUpdateUser(user);
                if (output > 0)
                {
                    _helper.UserForgotPasswordNotificationForSendOTMobileUser(user.MobileNo, user.Password);
                    result = true;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

       
    }
}
