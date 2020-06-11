using System;
using System.Collections.Generic;
namespace Tawjeeh.EntityModel
{
   public partial class Centers:BaseEntity
    {      
        public Centers()
        {
            Contacts = new HashSet<CenterContacts>();
            CenterTrans = new HashSet<CenterTrans>();
        }           
        public string Name { get; set; }        
        public string LocationAddress { get; set; }
        public long? EmiratesId { get; set; }       
        public string TradeLicense { get; set; }
        public DateTime? TradeLicenseExpiryDate { get; set; }      
        public string FaxNo { get; set; }        
        public string PhoneNo { get; set; }        
        public string WebSite { get; set; }       
        public string Email { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }       
        public virtual ICollection<CenterContacts> Contacts { get; set; }
        public virtual ICollection<CenterTrans> CenterTrans { get; set; }
        public virtual Emirates Emirates { get; set; }
    }
}
