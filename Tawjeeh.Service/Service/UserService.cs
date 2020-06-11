using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Tawjeeh.Entities;
using Tawjeeh.Entities.Password;
using Tawjeeh.Infrastructure;
using Tawjeeh.Repositories.Interface;
using Tawjeeh.Service.Interface;

namespace Tawjeeh.Service.Service
{
    public class UserService : IUserService
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(UserService));
        private IUserRepository _userRepo;
        private IContactRepository _contactRepo;
        private IHelper _helper;        
        int output = 0;
        public UserService(IUserRepository userRepo,
                           IContactRepository contactRepo,
                           IHelper helper)
        {
            Guard.NotNull(userRepo, nameof(userRepo));
            Guard.NotNull(contactRepo, nameof(contactRepo));

            _userRepo = userRepo;
            _contactRepo = contactRepo;
            _helper = helper;
          
        }
        public int Create(User user)
        {


            Utilities.Try(() =>
            {
                var passSettings = new PasswordSettings();
                //var password = Utilities.GeneratePassword(passSettings.IncludeLowercase, passSettings.IncludeUppercase,
                //    passSettings.IncludeNumeric, passSettings.IncludeSpecial, passSettings.IncludeSpaces, passSettings.LengthOfPassword);
                //user.Password = Utilities.Encrypt(password);
                if (user.MobileNo.Length < 7) throw new Exception("Mobile Number Should 12 digit., ex. 971500000000");
                var password = user.MobileNo.Substring(user.MobileNo.Length - 7);
                user.Password = Utilities.Encrypt(password);

                user.UserName = string.IsNullOrEmpty(user.UserName) ? user.Email : user.UserName;
                output = _userRepo.Create(user);
                if (output > 0)
                {
                    if (user.UserTypeId == (int)GlobalEnum.UserTypes.TawjeehDepartment)
                    {
                        var centers = _userRepo.GetUserById(output);
                        if (centers == null) throw new Exception("User is not exists.,");

                       //_helper.UserRegisterationNotificationToTawjeehDepartment(centers.MobileNo, centers.Email, password);
                    }
                }

            }, "Create User", log);

            return output;
        }
        public int Update(User user)
        {
            Utilities.Try(() =>
            {
                var result = _userRepo.GetUserById(user.Id);
                user.Password = result.Password;
                user.CreatedBy = result.CreatedBy;
                user.CreatedOn = result.CreatedOn;
                output = _userRepo.Update(user);
            }, "Update User", log);

            return output;
        }
        public int Delete(User user)
        {
            Utilities.Try(() =>
            {
                user.IsDeleted = true;
                user.UpdatedOn = DateTime.Now;
                output = _userRepo.Update(user);
            }, "Delete User", log);

            return output;
        }
        public User GetUserById(int id)
        {
            var user = new User();
            Utilities.Try(() =>
            {
                user = _userRepo.GetUserById(id);
            }, "GetUserById", log);

            return user;
        }
        public Task<IEnumerable<User>> GetAllUser()
        {
            return _userRepo.GetAllUser();

        }
        public Task<User> GetUserbyCredential(string userName, string password)
        {
            password = Utilities.Encrypt(password);
            return _userRepo.GetUserbyCredential(userName, password);
        }
      
        public User IsUserExist(string userName)
        {
            return _userRepo.IsUserExist(userName);
        }
        public int AddUserToCenter(User users)
        {
            var output = 0;
            Utilities.Try(() =>
            {
                using (var transaction = new TransactionScope())
                {

                    var user = AutoMapper.Mapper.Map<User>(users);
                    if (user.Id == 0)
                    {
                        user.UserName = String.IsNullOrEmpty(user.UserName) ? user.Email : user.UserName;
                        user.UserTypeId = (int)GlobalEnum.UserTypes.TawjeehCenters;           

                        var isExists = _userRepo.IsUserExist(user.UserName);
                        if (isExists != null) throw new Exception("This person is already exists and assigned to one center.,");
                        if (user.MobileNo.Length < 7) throw new Exception("Mobile Number Should 12 digit., ex. 971500000000");
                        //var passSettings = new Entities.Password.PasswordSettings();
                        //var password = Utilities.GeneratePassword(passSettings.IncludeLowercase, passSettings.IncludeUppercase,
                        //    passSettings.IncludeNumeric, passSettings.IncludeSpecial, passSettings.IncludeSpaces, passSettings.LengthOfPassword);
                        var password = user.MobileNo.Substring(user.MobileNo.Length - 7);
                        user.Password = Utilities.Encrypt(password);

                        var outuser = _userRepo.Create(user);
                        if (outuser == 0) throw new Exception("Unable to Contact into User table.,");
                        user.Id = outuser;
                        var contact = AutoMapper.Mapper.Map<CenterContacts>(user);

                        var outcontact = _contactRepo.ContactCreate(contact);
                        if (outcontact == 0) throw new Exception("Unable to add contact into centers.,");

                        if (user.ContactTypeId == (int)GlobalEnum.ContactType.CenterOwner)
                        {
                            //_helper.UserRegistrationNotificationForCenterOwners(user.MobileNo, user.Email, password);
                        }
                        if (user.ContactTypeId == (int)GlobalEnum.ContactType.CenterRepresentative)
                        {
                           // _helper.UserRegistrationNotificationForCenterRepresentative(user.MobileNo, user.Email, password);
                        }
                    }
                    else
                    {
                        var isExists = _userRepo.GetUserById(user.Id);
                        isExists.UserName = user.UserName;
                        isExists.Email = user.Email;
                        isExists.MobileNo = user.MobileNo;
                        isExists.OfficeNo = user.OfficeNo;
                        output = _userRepo.Update(isExists);
                        if(output > 0)
                        {
                            var contact = AutoMapper.Mapper.Map<CenterContacts>(isExists);
                            contact.ContactTypeId = user.ContactTypeId;
                            contact.CenterId = user.CenterId;
                            output = _contactRepo.ContactUpdate(contact);
                        }
                        else
                        {
                            throw new Exception("Ünable to update contacts.,");
                        }
                    }
                    transaction.Complete();
                    transaction.Dispose();
                    output = 1;
                }

            }, "AddUserToCenter(IList<User> users)", log);
            return output;
        }

        public IEnumerable<User> GetAllUserByUserType(long userTypeId)
        {
            return _userRepo.GetAllUserByUserType(userTypeId);
        }
        public User IsUserExist(string userName, string mobileNo)
        {
            return _userRepo.IsUserExist(userName, mobileNo);
        }
        public User RegisterUser(User user)
        {
            var userProfile = new User();
            Utilities.Try(() =>
            {
                using (var transaction = new TransactionScope())
                {
                    user.UserName = string.IsNullOrEmpty(user.UserName) ? user.Email : user.UserName;                   

                    var passSettings = new Entities.Password.PasswordSettings();
                    user.Password = Utilities.Encrypt(user.Password);
                    user.IsOTP = false;
                    user.OTP = Utilities.GenerateOTP(false, false,
                        true, false, false, 4);
                  

                    var output = _userRepo.RegisterUser(user);
                    if(output > 0)
                    {
                        _helper.UserRegistrationNotificationForSendOTMobileUser(user.MobileNo, user.OTP);
                        userProfile = _userRepo.GetUserById(output);
                        userProfile.Password = string.Empty;
                        userProfile.OTP = string.Empty;
                        transaction.Complete();
                        transaction.Dispose();
                    }                  

                }
            }, "RegisterUser(User user)", log);

            return userProfile;
        }

        public User ResendOTP(User user)
        {
            var userProfile = new User();
            Utilities.Try(() =>
            {
                using (var transaction = new TransactionScope())
                {
                    var passSettings = new PasswordSettings(); 
                    user = _userRepo.IsUserExist(user.Email,user.MobileNo);

                    if (user == null)
                        throw new Exception("User is not exists.,");

                    user.IsOTP = false;
                    user.OTP = Utilities.GenerateOTP(false, false,
                        true, false, false, 4);

                    var output = _userRepo.Update(user);
                    if (output > 0)
                    {
                        _helper.UserRegistrationNotificationForSendOTMobileUser(user.MobileNo, user.OTP);
                        userProfile = _userRepo.GetUserById(user.Id);
                        userProfile.Password = string.Empty;
                        userProfile.OTP = string.Empty;
                        transaction.Complete();
                        transaction.Dispose();
                    }
                }
            }, "ResendOTP(User user)", log);

            return userProfile;
        }

        public User VerifyOTP(User user)
        {           
            Utilities.Try(() =>
            {
                using (var transaction = new TransactionScope())
                {
                    var passSettings = new PasswordSettings();
                    var newOTP = user.OTP;
                    user = _userRepo.IsUserExist(user.Email,user.MobileNo);

                    if (user == null)
                        throw new Exception("User is not exists.,");

                    if (user.OTP == newOTP)
                    {
                        user.IsOTP = true;
                        var output = _userRepo.Update(user);
                        if (output > 0)
                        {                  
                            transaction.Complete();
                            transaction.Dispose();
                        }
                    }
                    else
                    {
                        throw new Exception("OTP does not match.,");
                    }
                }
            }, "ResendOTP(User user)", log);

            return user;
        }

        

        public User ResetPassword(User user)
        {
            throw new NotImplementedException();
        }

        public bool Login(string userName, string password)
        {
            password = Utilities.Encrypt(password);
            return _userRepo.Login(userName, password);
        }

        public User MobileRequestOTP(User user)
        {
            var userProfile = new User();
            Utilities.Try(() =>
            {
                using (var transaction = new TransactionScope())
                {                    
                    user.IsOTP = false;
                    user.OTP = Utilities.GenerateOTP(false, false,
                        true, false, false, 4);

                    var output = _userRepo.Update(user);
                    if (output > 0)
                    {
                        _helper.UserRegistrationNotificationForSendOTMobileUser(user.MobileNo, user.OTP);
                        userProfile = _userRepo.GetUserById(output);
                        userProfile.Password = string.Empty;
                        userProfile.OTP = string.Empty;
                        transaction.Complete();
                        transaction.Dispose();
                    }

                }
            }, "MobileRequestOTP(User user)", log);

            return userProfile;
        }
    }

}
