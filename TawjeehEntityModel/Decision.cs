using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tawjeeh.EntityModel
{
   public partial class Decision: BaseEntity
    {
        public Decision()
        {
            MultimediaDecisions = new HashSet<DecisionMultimedia>();
            DecisionTranslations = new HashSet<DecisionTrans>();          
        }        
        public string Name { get; set; }       
        public string Description { get; set; }        
        public string DecisionNo { get; set; }
        public long? ArticleId { get; set; }      
        public long? Year { get; set; }     
        public virtual Article Article { get; set; }
        public virtual ICollection<DecisionMultimedia> MultimediaDecisions { get; set; }
        public virtual ICollection<DecisionTrans> DecisionTranslations { get; set; }
        //[NotMapped]
        //public virtual Law Law { get; set; }
}
    }
