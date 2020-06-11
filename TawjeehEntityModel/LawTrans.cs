using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tawjeeh.EntityModel
{
  
   public partial class LawTrans:BaseEntity
    {      
        public string Name { get; set; }     
        public string Description { get; set; }
        public int? LangId { get; set; }
        public long? LawId { get; set; }        
        public virtual Law Law { get; set; }
    }
}
