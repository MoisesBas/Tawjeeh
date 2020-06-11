

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using Tawjeeh.Api.Models;
using Tawjeeh.EntityFramework.Helper;
using Tawjeeh.EntityModel;
using Tawjeeh.EntityServices.Interface;
using Tawjeeh.Infrastructure;
using Tawjeeh.Api.Plugins;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Tawjeeh.Api.Common;

namespace Tawjeeh.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Tawjeeh.Api.Controllers.BaseController" />
    [RoutePrefix("user")]
    public class UsersController : BaseController
    {
        /// <summary>
        /// The path
        /// </summary>
        private static string[] path = Utilities.MobilefilePath.Split(new char[] { '\\' });
        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        /// <param name="_serviceFactory">The service factory.</param>
        /// <param name="_sms">The SMS.</param>
        public UsersController(IServiceFactory _serviceFactory,ISms _sms) :
            base(_serviceFactory,_sms)
        {

        }
        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("GetAllUsers")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<User>))]
        public IHttpActionResult GetAllUsers()
        {
            var result = _serviceFactory.CreateUserService.GetAllUser();
            return Ok(result);
        }

        /// <summary>
        /// Adds the update user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("AddUpdateUser")]
        [HttpPut]
        [ResponseType(typeof(UpdateUserViewModel))]
        public IHttpActionResult AddUpdateUser(UpdateUserViewModel user)
        {
            var map = AutoMapper.Mapper.Map<User>(user);

            Guard.NotNullOrEmpty(user.Email, "Email Address is required.,");
            Guard.NotNullOrEmpty(user.UserName, "User Name is required.");
            Guard.NotDefault(user.UserTypeId, "User Type is required.,");

            if (user.UserTypeId == (int)GlobalEnum.UserTypes.TawjeehDepartment
            || user.UserTypeId == (int)GlobalEnum.UserTypes.TawjeehCenters)
            {
                map.LangId = Utilities.IsDefaultLang;
                Guard.NotNullOrEmpty(user.MobileNo, "Mobile number is required.");
            }
            var result = _serviceFactory.CreateUserService.InsertOrUpdate(map);
            return Ok(result);
        }
        /// <summary>
        /// Gets the type of all user by user.
        /// </summary>
        /// <param name="userTypeId">The user type identifier.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("GetAllUserByUserType")]
        [HttpGet]
        public IHttpActionResult GetAllUserByUserType(long userTypeId)
        {
            Guard.NotDefault(userTypeId, "User type id is null.,");
            var result = _serviceFactory.CreateUserService.GetAllUserByUserType(userTypeId);
            result.ToList().ForEach(x =>
            {
                x.Photo = string.IsNullOrEmpty(x.Photo) ? string.Empty : "/" + path[path.Length - 2] + "/" + path[path.Length - 1] + "/" + x.Photo.TrimStart('/');
            });

            var output = (from u in result
                          select new
                          {
                              u.Id,
                              u.UserTypeId,
                              ContactTypeId = u.CenterContacts.Where(x => x.UserId == u.Id).Select(x => x.ContactTypeId).DefaultIfEmpty(),
                              u.JobTitle,
                              u.UserName,
                              Password = string.Empty,
                              u.FullName,
                              u.OfficeNo,
                              u.Department,
                              u.MobileNo,
                              u.Email,
                              u.IsActive,
                              u.IsDeleted,
                              u.CreatedOn,
                              u.CreatedBy,
                              u.UpdatedBy,
                              u.UpdatedOn,
                              u.Photo,
                              CenterId = u.CenterContacts != null ? u.CenterContacts.Where(x => x.UserId == u.Id).Select(x => x.CenterId).FirstOrDefault() : 0,
                              Contacts = u.CenterContacts ?? null,
                              Center = u.CenterContacts?.Where(x => x.UserId == u.Id).Select(x => x.Centers)
                          }).ToList();


            Guard.NotNull(output, "User Not Exists");
            return Ok(output);
        }

        /// <summary>
        /// Adds the user to center.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Invalid Email Address for center contacts.,</exception>
        [AllowAnonymous]
        [Route("AddUserToCenter")]
        [HttpPost]
        [ResponseType(typeof(AddUpdateCenterUser))]
        public IHttpActionResult AddUserToCenter(AddUpdateCenterUser user)
        {
            Guard.NotNull(user, "Center is user is null");

            if (!Utilities.IsValidEmail(user.Email))
                throw new Exception("Invalid Email Address for center contacts.,");
            Guard.NotNullOrEmpty(user.UserName, "UserName is required.,");
            Guard.NotNullOrEmpty(user.MobileNo, "Invalid mobile number for center contacts.,");
            Guard.NotDefault(user.ContactTypeId, "Please select contact type.,");
            Guard.NotDefault(user.CenterId, "Please select center.,");

            var mapuser = AutoMapper.Mapper.Map<User>(user);
            var result = _serviceFactory.CreateUserService.InsertOrUpdate(mapuser);
            return Ok(result);
        }

        /// <summary>
        /// Deletes the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("DeleteUser")]
        [HttpPut]
        [ResponseType(typeof(UpdateUserViewModel))]
        public IHttpActionResult Delete(UpdateUserViewModel user)
        {
            var map = AutoMapper.Mapper.Map<User>(user);
            var result = _serviceFactory.CreateUserService.Delete(map);
            return Ok(result);
        }

        /// <summary>
        /// Mobiles the login.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        /// <exception cref="HttpResponseException">
        /// </exception>
        [AllowAnonymous]
        [Route("MobileLogin")]
        [HttpPut]
        [ResponseType(typeof(User))]
        public IHttpActionResult MobileLogin(string userName, string password)
        {

            if (userName.IsParamEmpty())
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "User Name is Required.,"));

            if (password.IsParamEmpty())
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Password is Required.,"));

            var result = _serviceFactory.CreateUserService.MobileLogin(userName, password);
            if (result != null)
            {
                result.Photo = string.IsNullOrEmpty(result.Photo) ? string.Empty : "/" + path[path.Length - 2] + "/" + path[path.Length - 1] + "/" + result.Photo.TrimStart('/');
                result.Password = string.Empty;
                result.OTP = string.Empty;
                return Ok(result);
            }
            else
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid User Name and Password.,"));
            }
           
        }
        /// <summary>
        /// Resets the password confirmation.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        /// <exception cref="HttpResponseException">
        /// </exception>
        [AllowAnonymous]
        [Route("ResetPasswordConfirmation")]
        [HttpPut]
        [ResponseType(typeof(ResetPasswordConfirmationViewModel))]
        public IHttpActionResult ResetPasswordConfirmation(ResetPasswordConfirmationViewModel user)
        {
            var isEmail = new EmailAddressAttribute();
            var isExists = new User();
            var isValidInput = false;
            var result = false;

            bool isValid = string.IsNullOrEmpty(user.Email) ? false
               : (isEmail.IsValid(user.Email) ? true : (user.Email.ValidatePhoneNumber(true) ? true : false));

            if (!isValid) throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Email Address or Mobile Number.,"));
            isExists = isEmail.IsValid(user.Email) ? _serviceFactory.CreateUserService.IsUserExist(user.Email)
                : _serviceFactory.CreateUserService.IsMobileUser(user.Email);

            if (isExists == null)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "User Not Exists.,"));

            if (isEmail.IsValid(user.Email))
            {
                if ((isExists.OTP == user.OTP) && isExists.Email.ToUpper() == user.Email.ToUpper())
                    isValidInput = true;
            }
            if (user.Email.ValidatePhoneNumber(true))
            {
                if ((isExists.OTP == user.OTP) && isExists.MobileNo == user.Email)
                    isValidInput = true;
            }

            if (isExists.OTP != user.OTP)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid OTP.,"));

            if (user.Password != user.ConfirmPassword)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Password and confirm password does not match.,"));

            isExists.OTP = user.OTP;
            isExists.IsOTP = true;
            isExists.UpdatedOn = DateTime.Now;
            isExists.Password = Utilities.Encrypt(user.Password);

            if (isValidInput)
            {
                result = _serviceFactory.CreateUserService.InsertOrUpdate(isExists) > 0 ? true : false;
                if (result == false) throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Unable to reset your password.,"));

            }
            else
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Unable to reset your password.,"));
            }

            return Ok(result);
        }

        /// <summary>
        /// Forgots the password.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        /// <exception cref="HttpResponseException">
        /// </exception>
        [AllowAnonymous]
        [Route("ForgotPassword")]
        [HttpPut]
        [ResponseType(typeof(ForgotPasswordViewModel))]
        public IHttpActionResult ForgotPassword(ForgotPasswordViewModel user)
        {
            var isEmail = new EmailAddressAttribute();
            var isValidInput = false;
            var result = false;
            var isExists = new User();

            bool isValid = string.IsNullOrEmpty(user.MobileNoOrEmail) ? false
                : (isEmail.IsValid(user.MobileNoOrEmail) ? true : (user.MobileNoOrEmail.ValidatePhoneNumber(true) ? true : false));

            if (!isValid) throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Email Address or Mobile Number.,"));
            isExists = isEmail.IsValid(user.MobileNoOrEmail) ? _serviceFactory.CreateUserService.IsUserExist(user.MobileNoOrEmail)
                : _serviceFactory.CreateUserService.IsMobileUser(user.MobileNoOrEmail);

            if (isExists == null)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "User Not Exists.,"));

            if (isEmail.IsValid(user.MobileNoOrEmail))
            {
                if ((isExists.OTP == user.OTP) && isExists.Email.ToUpper() == user.MobileNoOrEmail.ToUpper())
                    isValidInput = true;
            }
            if (user.MobileNoOrEmail.ValidatePhoneNumber(true))
            {
                if ((isExists.OTP == user.OTP) && isExists.MobileNo == user.MobileNoOrEmail)
                    isValidInput = true;
            }
            if (isValidInput)
            {
                result = _serviceFactory.CreateUserService.ForgotPassword(isExists);
                if (result == false) throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Unable to send OTP.,"));

            }
            else
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Unable to send OTP.,"));
            }
            return Ok(result);

        }

        /// <summary>
        /// Mobiles the resend otp.
        /// </summary>
        /// <param name="mobileOrEmail">The mobile or email.</param>
        /// <returns></returns>
        /// <exception cref="HttpResponseException">
        /// </exception>
        [AllowAnonymous]
        [Route("MobileResendOTP")]
        [HttpPut]
        public IHttpActionResult MobileResendOTP(string mobileOrEmail)
        {
            var isEmail = new EmailAddressAttribute();

            bool isValid = string.IsNullOrEmpty(mobileOrEmail) ? false
                : (isEmail.IsValid(mobileOrEmail) ? true : (mobileOrEmail.ValidatePhoneNumber(true) ? true : false));

            if (!isValid) throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Email Address or Mobile Number.,"));
            var isExists = isEmail.IsValid(mobileOrEmail) ? _serviceFactory.CreateUserService.IsUserExist(mobileOrEmail)
                : _serviceFactory.CreateUserService.IsMobileUser(mobileOrEmail);

            if (isExists == null)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "User Not Exists.,"));

            var mapuser = AutoMapper.Mapper.Map<User>(isExists);
            var result = _serviceFactory.CreateUserService.ResendOTP(mapuser);
            return Ok((result != null ? true : false));
        }

        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("GetUserById")]
        [HttpGet]
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUserById(int id)
        {
            Guard.NotDefault(id, "UserId is null.,");
            var result = _serviceFactory.CreateUserService.GetUserById(id);
            if (result != null)
            {
                result.Photo = string.IsNullOrEmpty(result.Photo) ? string.Empty : "/" + path[path.Length - 2] + "/" + path[path.Length - 1] + "/" + result.Photo.TrimStart('/');
                result.Password = string.Empty;
                result.OTP = string.Empty;
            }
            Guard.NotNull(result, "User Not Exists");
            return Ok(result);
        }
        /// <summary>
        /// Updates the user profile.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Invalid Email Address.,</exception>
        /// <exception cref="HttpResponseException">
        /// </exception>
        [AllowAnonymous]
        [Route("UpdateUserProfile")]
        [HttpPut]
        [ResponseType(typeof(UpdateUserProfile))]
        public IHttpActionResult UpdateUserProfile(UpdateUserProfile user)
        {
            var result = false;

            Guard.NotNull(user, "User is Null.,");
            if (!Utilities.IsValidEmail(user.Email))
                throw new Exception("Invalid Email Address.,");
            Guard.NotNullOrEmpty(user.MobileNo, "Invalid mobile number.,");

            var isExists = _serviceFactory.CreateUserService.GetUserById(user.Id);
            if (isExists == null) throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Conflict, "User Not Exists.,"));

            isExists.UserTypeId = user.UserTypeId;
            isExists.FullName = user.FullName;
            isExists.Email = user.Email;
            isExists.MobileNo = user.MobileNo;
            isExists.CountryId = user.CountryId;
            isExists.Gender = user.Gender;
            result = _serviceFactory.CreateUserService.InsertOrUpdate(isExists) > 0 ? true : false;
            if (!result) throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Conflict, "Unable to update your profile"));
            return Ok(result);
        }

        /// <summary>
        /// Registers the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Invalid Email Address.,</exception>
        /// <exception cref="HttpResponseException">
        /// </exception>
        [AllowAnonymous]
        [Route("RegisterUser")]
        [HttpPut]
        [ResponseType(typeof(RegisterUserViewModel))]
        public IHttpActionResult RegisterUser(RegisterUserViewModel user)
        {
            var result = new User();

            Guard.NotNull(user, "Center is user is null");
            if (!Utilities.IsValidEmail(user.Email))
                throw new Exception("Invalid Email Address.,");

            Guard.NotNullOrEmpty(user.MobileNo, "Invalid mobile number.,");
            Guard.NotNullOrEmpty(user.Password, "Password is required.,");
            Guard.NotNullOrEmpty(user.ConfirmPassword, "Please confirm password.,");

            if (!user.Password.ToLower().Equals(user.ConfirmPassword.ToLower()))
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Conflict, "Password and Confirm password does not match.,"));

            var isMobileExists = _serviceFactory.CreateUserService.IsMobileUser(user.MobileNo);
            if (isMobileExists != null)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Conflict, "Mobile Number is already taken.,"));

            var isExists = _serviceFactory.CreateUserService.IsUserExist(user.Email);
            if (isExists != null)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Conflict, "Email Address is already taken.,"));

            if (isExists != null && isExists.IsOTP == false)
            {
                isExists.MobileNo = user.MobileNo;
                isExists.Email = user.Email;
                result = _serviceFactory.CreateUserService.MobileRequestOTP(isExists);
            }
            else
            {
                var mapuser = AutoMapper.Mapper.Map<User>(user);
                result = _serviceFactory.CreateUserService.RegisterUser(mapuser);

            }
            result.Photo = string.IsNullOrEmpty(result.Photo) ? string.Empty : "/" + path[path.Length - 2] + "/" + path[path.Length - 1] + "/" + result.Photo.TrimStart('/');
            return Ok(result);
        }

        /// <summary>
        /// Verifies the otp.
        /// </summary>
        /// <param name="verifyOTP">The verify otp.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Invalid email address.,</exception>
        [AllowAnonymous]
        [Route("VerifyOTP")]
        [HttpPut]
        [ResponseType(typeof(User))]
        public IHttpActionResult VerifyOTP(VerifyOTPViewModel verifyOTP)
        {
            if (!Utilities.IsValidEmail(verifyOTP.Email))
                throw new Exception("Invalid email address.,");
            Guard.NotNullOrEmpty(verifyOTP.MobileNo, "Invalid mobile number for requesting OTP.,");
            Guard.NotNullOrEmpty(verifyOTP.OTP, "Invalid OTP.,");

            var mapuser = AutoMapper.Mapper.Map<User>(verifyOTP);
            var result = _serviceFactory.CreateUserService.VerifyOTP(mapuser);
            return Ok(result);
        }

        /// <summary>
        /// Uploads the photo asynchronous.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="HttpResponseException">
        /// </exception>
        /// <exception cref="Exception">Id is required.</exception>
        [AllowAnonymous]
        [Route("UploadPhoto")]
        [HttpPost]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> UploadPhotoAsync()
        {
            string photoFolderPath = Utilities.MobilefilePath;
            string UploadFilePath = string.Empty;

            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.UnsupportedMediaType));
            }

            UploadFilePath = UploadFile();

            StreamProvider streamProvider = new StreamProvider(UploadFilePath);
            var result = await Request.Content.ReadAsMultipartAsync(streamProvider);
            IEnumerable<string> FileDataNames = streamProvider.FileData.Select
                (entry => entry.LocalFileName.Replace(photoFolderPath, ""));

            string _FileName = "";
            foreach (string value in FileDataNames)
                _FileName = value.Replace("\\", "//");
            if (Convert.ToUInt64(result.FormData.GetValues("Id")[0]) == 0)
                throw new Exception("Id is required.");

            var id = Convert.ToInt32(result.FormData.GetValues("Id")[0]);
            var user = _serviceFactory.CreateUserService.GetUserById(id);
            if (user == null)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "User Not Found.,"));

            user.Photo = _FileName;
            var output = _serviceFactory.CreateUserService.InsertOrUpdate(user);
            return Ok(output);

        }

        /// <summary>
        /// Uploads the file.
        /// </summary>
        /// <returns></returns>
        public string UploadFile()
        {
            var directoryPath = Utilities.MobilefilePath;
            DirectoryInfo DirInfo = new DirectoryInfo(directoryPath);
            DirectorySecurity DirPermission = new DirectorySecurity();
            FileSystemAccessRule FRule = new FileSystemAccessRule("Everyone", FileSystemRights.ReadAndExecute, AccessControlType.Allow);
            DirPermission.AddAccessRule(FRule);
            if (!DirInfo.Exists)
            {
                Directory.CreateDirectory(directoryPath);
            }

            return directoryPath;
        }
    }
}
