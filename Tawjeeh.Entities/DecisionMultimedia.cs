using Dapper.Contrib.Extensions;
using System;

namespace Tawjeeh.Entities
{
    [Table("tblDecisionMultimedia")]
    public class DecisionMultimedia
    {
        [Key]
        public Int64 Id { get; set; }
        public Int64? DecisionId { get; set; }    
        public int? LangId { get; set; }
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public string VideoUrl { get; set; }
        public int FileType { get; set; }
        public Int64 CntLikes { get; set; }
        public Int64 CntDisLikes { get; set; }
        public Int64 CntViews { get; set; }
        public string Description { get; set; }
        public bool IsMobile { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Int64? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Int64? UpdatedBy { get; set; }
    }
}
