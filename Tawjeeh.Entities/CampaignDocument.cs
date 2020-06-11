using Dapper.Contrib.Extensions;
using System;

namespace Tawjeeh.Entities
{
    [Table("tblCampaignDocument")]
    public class CampaignDocument
    {
        [Key]
        public Int64 Id { get; set; }
        public Int64? CampaignId { get; set; }
        public Int64? CampaignDetailsId { get; set; }
        public string DocumentTitle { get; set; }
        public string DocumentPath { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Int64? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Int64? UpdatedBy { get; set; }
    }
}
