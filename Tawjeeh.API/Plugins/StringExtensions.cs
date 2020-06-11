
using System.Text.RegularExpressions;

namespace Tawjeeh.Api.Plugins
{
    public static class StringExtensions
    {

        public static bool ValidatePhoneNumber(this string phone, bool IsRequired)
        {
            if (string.IsNullOrEmpty(phone) & !IsRequired)
                return true;

            if (string.IsNullOrEmpty(phone) & IsRequired)
                return false;

            var cleaned = phone.RemoveNonNumeric();
            if (IsRequired)
            {
                if (cleaned.Length == 12)
                    return true;
                else
                    return false;
            }
            else
            {
                if (cleaned.Length == 0)
                    return true;
                else if (cleaned.Length > 0 & cleaned.Length < 12)
                    return false;
                else if (cleaned.Length == 12)
                    return true;
                else
                    return false;
            }
        }

        public static bool IsParamEmpty(this string param)
        {
            if (string.IsNullOrEmpty(param))
                return true;
            return false;
        }


        public static string RemoveNonNumeric(this string phone)
        {
            return Regex.Replace(phone, @"[^0-9]+", "");
        }
    }
}