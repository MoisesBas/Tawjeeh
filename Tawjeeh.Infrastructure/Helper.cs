using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using Tawjeeh.Infrastructure.SMS;

namespace Tawjeeh.Infrastructure
{
    public class Helper : IHelper
    {
        public static string COMPANY_USER_LOGIN_LINK = "";
        private ISms _sms;
        public static string BaseURL
        {
            get
            {
                return HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.ApplicationPath.TrimEnd('/') + "/";
            }
        }
        public Helper(ISms sms)
        {
            _sms = sms;
        }

        public double GetPercentage(double current, double maximum)
        {
            return (current / maximum) * 100;
        }

        public async Task<SmsSentMessages> UserRegisterationNotificationToTawjeehDepartment(string Number, string Email, string Password)
        {
            string msg = GetContent(GlobalEnum.SMSTempates.TawjeehDepartmentUserRegistration);
            msg = msg.Replace("[[LoginLink]]", BaseURL)
                .Replace("[[UserName]]", Email)
                .Replace("[[Password]]", Password);
            return await _sms.Send(Number, msg);

        }

        public async Task<SmsSentMessages> UserRegistrationNotificationForCenterOwners(string Number, string Email, string Password)
        {
            string msg = GetContent(GlobalEnum.SMSTempates.CenterOwnerUserRegistration);
            msg = msg.Replace("[[LoginLink]]", BaseURL)
                .Replace("[[UserName]]", Email)
                .Replace("[[Password]]", Password);
            return await _sms.Send(Number, msg);
        }

        public async Task<SmsSentMessages> UserRegistrationNotificationForCenterRepresentative(string Number, string Email, string Password)
        {
            string msg = GetContent(GlobalEnum.SMSTempates.CenterRepresentativeUserRegistration);
            msg = msg.Replace("[[LoginLink]]", COMPANY_USER_LOGIN_LINK)
                .Replace("[[UserName]]", Email)
                .Replace("[[Password]]", Password);
            return await _sms.Send(Number, msg);
        }
        public async Task<SmsSentMessages> UserRegistrationNotificationForSendOTMobileUser(string Number, string OTP)
        {
            string msg = GetContent(GlobalEnum.SMSTempates.OTPUserRegistration);
            msg = msg.Replace("[[OTP]]", OTP);
            return await _sms.Send(Number, msg);
        }

        public async Task<SmsSentMessages> UserForgotPasswordNotificationForSendOTMobileUser(string Number, string Password)
        {
            Password = Utilities.Decrypt(Password);
            string msg = GetContent(GlobalEnum.SMSTempates.ResetPassword);
            msg = msg.Replace("[[PASSWORD]]", Password);
            return await _sms.Send(Number, msg);
        }
        public string GetContent(GlobalEnum.SMSTempates val)
        {
            string content = "";
            try
            {
                DescriptionAttribute[] attributes = (DescriptionAttribute[])val.GetType().GetField(val.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
                string path = attributes.Length > 0 ? attributes[0].Description : string.Empty;
                if (path != "")
                {
                    content = File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath(path));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return content;
        }
    }
}
