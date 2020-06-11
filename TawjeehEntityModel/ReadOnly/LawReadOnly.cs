using System;
using System.Collections.Generic;
using System.Text;

namespace Tawjeeh.EntityModel.ReadOnly
{
   public class LawReadOnly
    {
        public LawReadOnly()
        {
            Articles = new HashSet<Article>();
            LawTranslations = new HashSet<LawTrans>();
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
        public virtual ICollection<LawTrans> LawTranslations { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public int MultimediaCnt { get; set; }
        public int DecisionCnt { get; set; }
    }
}
