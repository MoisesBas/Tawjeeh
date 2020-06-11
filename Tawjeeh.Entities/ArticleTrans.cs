using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace Tawjeeh.Entities
{

    [Table("tblArticleTrans")]
    public class ArticleTrans
    {
        public ArticleTrans()
        {
            ArticleMultimedia = new List<ArticleMultimedia>();
            DecisionTrans = new List<DecisionTrans>();
            DecisionMultimedia = new List<DecisionMultimedia>();
        }
        [Key]
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public Int64? ArticleId { get; set; }
        public string ArticleNo { get; set; }
        public int? LangId { get; set; }        
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Int64? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Int64? UpdatedBy { get; set; }
        [Write(false)]
        public IList<ArticleMultimedia> ArticleMultimedia { get; set; }
        [Write(false)]
        public IList<DecisionTrans> DecisionTrans { get; set; }
        [Write(false)]
        public IList<DecisionMultimedia> DecisionMultimedia { get; set; }

    }
}
