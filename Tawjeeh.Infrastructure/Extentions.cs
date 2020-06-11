using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using Tawjeeh;

namespace Tawjeeh.Infrastructure
{
    public static class Extentions
    {
        public static int ToStatusCode(GlobalEnum.StatusCode val)
        {
            return (int)val;
        }

        public static string ToStatusMessage(GlobalEnum.StatusCode val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val.GetType().GetField(val.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
        
        public static string GetContent(GlobalEnum.SMSTempates val)
        {
            string content = "";
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val.GetType().GetField(val.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            string path = attributes.Length > 0 ? attributes[0].Description : string.Empty;
            if (path != "")
            {
                content = File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath(path));
            }
            return content;
        }
      

    }
}
