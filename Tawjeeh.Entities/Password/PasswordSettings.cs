using System;
using System.Configuration;

namespace Tawjeeh.Entities.Password
{
    public  class PasswordSettings
    {
        public bool IncludeLowercase {
            get {
                return Convert.ToBoolean(ConfigurationManager.AppSettings["includeLowercase"]);
            }
        }
        public bool IncludeUppercase { get {
                return Convert.ToBoolean(ConfigurationManager.AppSettings["includeUppercase"]);
            }
        }
        public bool IncludeNumeric { get
            {
                return Convert.ToBoolean(ConfigurationManager.AppSettings["includeNumeric"]);
            }
        }
        public bool IncludeSpecial
        {
            get
            {
                return Convert.ToBoolean(ConfigurationManager.AppSettings["includeSpecial"]);
            }
        }
        public bool IncludeSpaces
        {
            get
            {
                return Convert.ToBoolean(ConfigurationManager.AppSettings["includeSpaces"]);
            }
        }
        public int LengthOfPassword
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["lengthOfPassword"]);
            }
        }       
    }
}
