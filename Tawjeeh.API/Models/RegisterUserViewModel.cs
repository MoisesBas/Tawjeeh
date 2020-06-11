using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tawjeeh.Api.Models
{
    public class RegisterUserViewModel
    {
        public Int64 Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string MobileNo { get; set; }
        public int? Nationality { get; set; }
        public Int64? UserTypeId { get; set; }
    }
}