using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tawjeeh.Api.Models
{
    public class UpdateUserProfile
    {
        public int Id { get; set; }
        public int UserTypeId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public int? CountryId { get; set; }
        public string Gender { get; set; }
    }
}