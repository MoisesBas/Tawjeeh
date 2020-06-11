using Dapper.Contrib.Extensions;
using System;

namespace Tawjeeh.Entities
{

    [Table("tblGoal")]
    public class Goal
    {
        [Key]
        public Int64 Id { get; set; }
        public Int64 CampaignId { get; set; }
        public string Objective { get; set; }
        public string Target { get; set; }
        public string Actual { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Int64? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Int64? UpdatedBy { get; set; }


    }
}
