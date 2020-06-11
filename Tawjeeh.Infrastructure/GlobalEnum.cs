using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tawjeeh.Infrastructure
{
    public class GlobalEnum
    {
        public enum NotificationType
        {
            PushNotification = 1,
            SMS = 2,
            Email = 3
        }
        public enum CampaignType
        {
            Article = 1,
            Decision = 2,
            Law = 3,
            Others = 4,
            Initiative = 5
        }
        public enum Target
        {
            Mohre = 1,
            Labor = 2,
            Owner = 3,
            All = 4
        }
        public enum UserTypes
        {
            SuperAdmin = 1,
            TawjeehDepartment = 2,
            TawjeehCenters = 3,
            TawjeehMobile = 4,
            CompanyUsers = 5
        }

        public enum MobileStatus
        {
            Like = 1,
            DisLike = 2,
            View = 3
        }

        public enum ContactType
        {
            CenterOwner = 1,
            CenterRepresentative = 2
        }
        public enum SMSTempates
        {
            [Description("~/Templates/SMS/UserRegister.txt")]
            UserRegistration = 1,
            [Description("~/Templates/SMS/ContactCentersUserRegistration.txt")]
            ContactCentersUserRegistration = 2,
            [Description("~/Templates/SMS/TawjeehDepartmentUserRegistration.txt")]
            TawjeehDepartmentUserRegistration = 3,
            [Description("~/Templates/SMS/CenterOwnerUserRegistration.txt")]
            CenterOwnerUserRegistration = 4,
            [Description("~/Templates/SMS/CenterRepresentativeUserRegistration.txt")]
            CenterRepresentativeUserRegistration = 5,
            [Description("~/Templates/SMS/OTPUserRegistration.txt")]
            OTPUserRegistration = 6,
            [Description("~/Templates/SMS/InitiativeCampaign.txt")]
            InitiativeCampaign = 7,
            [Description("~/Templates/SMS/ResetPassword.txt")]
            ResetPassword = 8,

        }
        public enum StatusCode
        {
            [Description("Authentication Failed")]
            AuthenticationFailed = 401,

            [Description("Server Exception")]
            Exception = 500,

            [Description("Operation Successful")]
            Success = 100,

            [Description("Operation Failed and Transaction Rollback")]
            Failed = 101,

            [Description("Record Not Found")]
            RecordNotFound = 204,
        }

    }
}
