using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace Tawjeeh.Entities
{   
    [Table("tblUser")]
    public class User
    {[Key]
        public int Id { get; set; }
        public int UserTypeId { get; set; }
        [Write(false)]
        public int? ContactTypeId { get; set; }        
        [Write(false)]
        public Int64? CenterId { get; set; }
        [Write(false)]
        public Centers Center { get; set; }
        public string JobTitle { get; set; }
        public string UserName { get; set; } 
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public bool IsOTP { get; set; }
        public string OTP { get; set; }
        public int? LangId { get; set; }
        public int? CountryId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string OfficeNo { get; set; }
        public string Department { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        
        [Write(false)]      
        public UserType UserType { get; set;}
        [Write(false)]
        
        public IEnumerable<MenuAccess> MenuAccess { get; set; }
        [Write(false)]
        public CenterContacts Contacts { get; set; }
       
    }
}
