using System;
using System.Collections.Generic;
using System.Text;

namespace Tawjeeh.EntityModel
{
    public partial class CenterTrans : BaseEntity
    {
        public string Name { get; set; }
        public string LocationAddress { get; set; }
        public long? CenterId { get; set; }
        public int? LangId { get; set; }
        public long? EmiratesId { get; set; }
        public string TradeLicense { get; set; }
        public DateTime? TradeLicenseExpiryDate { get; set; }
        public string FaxNo { get; set; }
        public string PhoneNo { get; set; }
        public string WebSite { get; set; }
        public string Email { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public virtual Centers Centers { get; set; }
        public virtual Emirates Emirates { get; set; }

    }
}
