using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace Tawjeeh.Entities
{
    [Table("tblDecision")]
    public class Decision
    {
        public Decision()
        {
            MultimediaDecisions = new List<DecisionMultimedia>();
            DecisionTranslations = new List<DecisionTrans>();
            Articles = new Article();
            Laws = new Law();
        }
        [Key]
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public string DecisionNo { get; set; }
        public string Description { get; set; }
        [Write(false)]
        public IList<DecisionTrans> DecisionTranslations { get; set; }
        [Write(false)]
        public IList<DecisionMultimedia> MultimediaDecisions { get; set; }
        [Write(false)]
        public Article Articles { get; set; }
        [Write(false)]
        public Law Laws { get; set; }
        public Int64? ArticleId { get; set; }
        public Int64? Year { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Int64? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Int64? UpdatedBy { get; set; }
    }
}
