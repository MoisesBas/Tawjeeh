using Dapper.Contrib.Extensions;
using System;

namespace Tawjeeh.Entities
{
    [Table("tblCompany")]
    public class Company
    {
        [Key]
        public Int64? Id { get; set; }
        public String Name { get; set; }
        public Int16? NumberOfBrances { get; set; }
        public String HeadQuarterLocation { get; set; }
        public String Telephone { get; set; }
        public String website { get; set; }
        public String CompanyEmail { get; set; }
        public Int32? CompanyTypeID { get; set; }
        public String TradeLicense { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Int64? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Int64? UpdatedBy { get; set; }

    }
}
