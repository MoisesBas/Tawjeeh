using System;
using System.Collections.Generic;

namespace Tawjeeh.EntityModel
{
    public partial class ContactType:BaseEntity
    {      
        public ContactType()
        {
            CenterContacts = new HashSet<CenterContacts>();
        }
        public string Name { get; set; }      
        public string Description { get; set; }
        public virtual ICollection<CenterContacts> CenterContacts { get; set; }
    }
}
