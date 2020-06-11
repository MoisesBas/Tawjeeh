
using System;

namespace Tawjeeh.Api.Models
{
    
    public class UpdateUserViewModel
    {
        public Int64 Id { get; set; }
        public Int64 UserTypeId { get; set; }
        public string JobTitle { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string OfficeNo { get; set; }
        public string Department { get; set; }
        
    }
}