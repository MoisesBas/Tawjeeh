using System;
using System.Collections.Generic;
using System.Text;

namespace Tawjeeh.EntityModel.ReadOnly
{
    public class DecisionTransReadOnly
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long? DecisionId { get; set; }
        public string DecisionNo { get; set; }
        public long? ArticleId { get; set; }
        public int? LangId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public IEnumerable<DecisionMultimedia> DecisionMultimedia { get; set; }
    }
}
