using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace Tawjeeh.Entities
{
    [Table("tblCenterTrans")]
    public class CenterTrans
    {
        public CenterTrans()
        {
            Contacts = new List<CenterContacts>();
            User = new List<User>();
        }

        [Key]
        public Int64 Id { get; set; }
        public Int64 CenterId { get; set; }
        public int LangId { get; set; }
        public string Name { get; set; }
        public string LocationAddress { get; set; }
        public Int64 EmiratesId { get; set; }
        [Write(false)]
        public Emirates Emirates { get; set; }
        public string TradeLicense { get; set; }
        public DateTime? TradeLicenseExpiryDate { get; set; }
        public string FaxNo { get; set; }
        public string PhoneNo { get; set; }
        public string WebSite { get; set; }
        public string Email { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Int64? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Int64? UpdatedBy { get; set; }
        [Write(false)]
        public IList<CenterContacts> Contacts { get; set; }
        [Write(false)]
        public IList<User> User { get; set; }

        
    }
}
