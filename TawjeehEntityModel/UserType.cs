using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace Tawjeeh.EntityModel
{
  
    public partial class UserType:BaseEntity
    {   
        public UserType()
        {
            Users = new HashSet<User>();
        }        
        public string Name { get; set; }
        public string Description { get; set; }       
        public virtual ICollection<User> Users { get; set; }
    }
}
