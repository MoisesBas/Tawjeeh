using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace Tawjeeh.Entities
{

    [Table("tblDecisionTrans")]
    public class DecisionTrans
    {
        public DecisionTrans()
        {
            DecisionMultimedia = new List<DecisionMultimedia>();
        }
        [Key]
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public Int64? ArticleId { get; set; }
        public Int64? DecisionId { get; set; }
        public string DecisionNo { get; set; }
        [Write(false)]
        public IList<DecisionMultimedia> DecisionMultimedia { get; set; }
        public int? LangId { get; set; }
        public string Description { get; set; }       
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Int64? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Int64? UpdatedBy { get; set; }
    }
}
