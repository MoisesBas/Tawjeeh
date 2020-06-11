using System;

namespace Tawjeeh.Api.Models
{
    public class AddUpdateArticleTrans
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Int64? ArticleId { get; set; }
        public string ArticleNo { get; set; }
        public Int64? LangId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public Int64? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Int64? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}