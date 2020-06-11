
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tawjeeh.Entities
{
  
    public class Law
    {
        public Law()
        {
            this.LawTranslation = new List<LawTrans>();
            this.Articles = new List<Article>();
        }
        [Key]
        public Int64 Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public Int64? LangId { get; set; }       
        public IList<LawTrans> LawTranslation { get; set; }
        [NotMapped]
        public IList<Article> Articles { get; set; }       
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        [NotMapped]
        public int DecisionCnt { get; set; }
        [NotMapped]
        public int MultimediaCnt { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Int64? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Int64? UpdatedBy { get; set; }

       
    }
}
