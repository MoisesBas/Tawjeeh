using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace Tawjeeh.Entities
{
    [Table("tblCenters")]
    public class Centers
    {
        public Centers()
        {
            Contacts = new List<CenterContacts>();
            CenterTranslation = new List<CenterTrans>();
            Emirates = new Emirates();
            User = new List<User>();
        }

        [Key]
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public string LocationAddress { get; set; }       
        public Int64 EmiratesId { get; set; }
        [Write(false)]
        public Emirates Emirates { get; set; }
        [Write(false)]
        public IList<CenterTrans> CenterTranslation { get; set; }      
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
