using System.Configuration;

namespace Tawjeeh.SMSBulkSending.Helper
{
    public static class Utilities
    {
        public static string AppId => ConfigurationManager.AppSettings["appId"];
        public static string priority => ConfigurationManager.AppSettings["priority"];
        public static string deviceToken => ConfigurationManager.AppSettings["deviceToken"];
        public static string fcmURL => ConfigurationManager.AppSettings["fcmURL"];
    }
}
