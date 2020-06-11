using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tawjeeh.Infrastructure.SMS;

namespace Tawjeeh.Infrastructure
{
   public interface IHelper
    {
        double GetPercentage(double current, double maximum);
        Task<SmsSentMessages> UserRegisterationNotificationToTawjeehDepartment(string Number, string Email, string Password);
        Task<SmsSentMessages> UserRegistrationNotificationForCenterOwners(string Number, string Email, string Password);
        Task<SmsSentMessages> UserRegistrationNotificationForCenterRepresentative(string Number, string Email, string Password);
        Task<SmsSentMessages> UserRegistrationNotificationForSendOTMobileUser(string Number, string OTP);
        Task<SmsSentMessages> UserForgotPasswordNotificationForSendOTMobileUser(string Number, string Password);
        string GetContent(GlobalEnum.SMSTempates val);
    }
}
