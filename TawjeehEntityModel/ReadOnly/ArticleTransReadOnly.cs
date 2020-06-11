using System;
using System.Collections.Generic;
using System.Text;

namespace Tawjeeh.EntityModel.ReadOnly
{
   public class ArticleTransReadOnly
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public Int64? ArticleId { get; set; }
        public string ArticleNo { get; set; }
        public int? LangId { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Int64? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Int64? UpdatedBy { get; set; }      
        public IEnumerable<ArticleMultimedia> ArticleMultimedia { get; set; }       
        public IEnumerable<DecisionTrans> DecisionTrans { get; set; }       
        public IEnumerable<DecisionMultimedia> DecisionMultimedia { get; set; }
    }
}
