using System.Collections.Generic;

namespace Tawjeeh.EntityModel
{
  public partial  class Emirates:BaseEntity
    {       
        public Emirates()
        {
            Centers = new List<Centers>();
            CenterTrans = new List<CenterTrans>();
        }
        public string Name { get; set; } 
        public virtual ICollection<Centers> Centers { get; set; }
        public virtual ICollection<CenterTrans> CenterTrans { get; set; }
    }
}
