using Dapper.Contrib.Extensions;
using System;

namespace Tawjeeh.Entities
{
    [Table("tblInitiativeCampaign")]
    public class InitiativeCampaign
    {
        [Key]
        public Int64 Id { get; set; }
        public Int64? CampaignId { get; set; }
        [Write(false)]
        public Campaign Campaign { get; set; }
        public String Result { get; set; }
        public String EvidenceResult { get; set; }
        public String EvidenceName { get; set; }
        [Write(false)]
        public Initiative Initiative { get; set; }
        public Int64? InitiativeId { get; set;}
        public DateTime? StartDateTime { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
        public string Target { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Int64? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Int64? UpdatedBy { get; set; }
    }
}
