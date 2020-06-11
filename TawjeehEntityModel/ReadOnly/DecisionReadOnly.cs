using System;
using System.Collections.Generic;
using System.Text;

namespace Tawjeeh.EntityModel.ReadOnly
{
   public class DecisionReadOnly
    {
        public DecisionReadOnly()
        {
            MultimediaDecisions = new List<DecisionMultimedia>();
            DecisionTranslations = new List<DecisionTrans>();
        }
        public long Id { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string DecisionNo { get; set; }
        public long? ArticleId { get; set; }
        public long? Year { get; set; }
        public Article Article { get; set; }
        public IEnumerable<DecisionMultimedia> MultimediaDecisions { get; set; }
        public IEnumerable<DecisionTrans> DecisionTranslations { get; set; }
        public Law Law { get; set; }
    }
}
