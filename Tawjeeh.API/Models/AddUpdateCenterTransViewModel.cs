using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tawjeeh.Api.Models
{
    public class AddUpdateCenterTransViewModel
    {
        
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public string LocationAddress { get; set; }
        public Int64? CenterId { get; set; }
        public int LangId { get; set; }
        public Int64? EmiratesId { get; set; }
        public string TradeLicense { get; set; }
        public DateTime? TradeLicenseExpiryDate { get; set; }
        public string FaxNo { get; set; }
        public string PhoneNo { get; set; }
        public string WebSite { get; set; }
        public string Email { get; set; }
        public float? Longitude { get; set; }
        public float? Latitude { get; set; }
        public Int64? CreatedBy { get; set; }       
        public Int64? UpdatedBy { get; set; }
       
    }
}