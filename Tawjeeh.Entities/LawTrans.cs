
using System;
using System.ComponentModel.DataAnnotations;

namespace Tawjeeh.Entities
{
   
   
    public class LawTrans
    {
        public LawTrans()
        {
            Law = new Law();
        }
        [Key]
        public Int64 Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public Int64? LawId { get; set; }
        public Law Law { get; set; }
        public int? LangId { get; set; }   
      
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }       
        public DateTime? CreatedOn { get; set; }
        public Int64? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Int64? UpdatedBy { get; set; }

       
    }
}
