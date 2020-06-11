using System;
using System.Collections.Generic;
using System.Text;

namespace Tawjeeh.EntityModel
{
   public partial class DecisionTrans:BaseEntity
    {              
        public string Name { get; set; }      
        public string Description { get; set; }
        public long? DecisionId { get; set; }      
        public string DecisionNo { get; set; }
        public long? ArticleId { get; set; }
        public int? LangId { get; set; }      
        public virtual Decision Decision { get; set; }

    }
}
