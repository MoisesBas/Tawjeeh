using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tawjeeh.Notification.Helper
{
  public static  class Utilities
    {
        public static string AppId => ConfigurationManager.AppSettings["appId"];
        public static string priority => ConfigurationManager.AppSettings["priority"];
        public static string deviceToken => ConfigurationManager.AppSettings["deviceToken"];
        public static string SenderId => ConfigurationManager.AppSettings["senderId"];
        public static string fcmURL => ConfigurationManager.AppSettings["fcmURL"];
        public static int Interval => int.Parse(ConfigurationManager.AppSettings["interval"] ?? (1 * 60 * 1000).ToString());
    }
}
