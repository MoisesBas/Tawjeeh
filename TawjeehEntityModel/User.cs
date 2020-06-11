using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Tawjeeh.EntityModel
{
  
   public partial class User:BaseEntity
    {    
        public User()
        {
            CenterContacts = new HashSet<CenterContacts>();
        }
        public long? UserTypeId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string OfficeNo { get; set; }
        public string Department { get; set; }
        public string JobTitle { get; set; }
        public string MobileNo { get; set; }
        public string Photo { get; set; }
        public string Email { get; set; }      
        public bool IsOTP { get; set; }
        public string OTP { get; set; }
        public int? LangId { get; set; }
        public int? CountryId { get; set; }
        public long? CompanyId { get; set; }
        public string Gender { get; set; }
        public virtual ICollection<CenterContacts> CenterContacts { get; set; }
        public virtual UserType UserTypes { get; set; }
        public virtual Country Country { get; set; }
    }
}
