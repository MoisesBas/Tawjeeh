using System;
using System.Collections.Generic;
using System.Text;

namespace Tawjeeh.EntityModel
{
  public partial  class InitiativeType:BaseEntity
    {
        public InitiativeType()
        {
            Initiatives = new HashSet<Initiative>();
        }              
        public string Description { get; set; }       
        public virtual ICollection<Initiative> Initiatives { get; set; }
    }
}
