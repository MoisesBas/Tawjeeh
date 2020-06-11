﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tawjeeh.EntityModel
{
   public partial class Country
    {
        public Country()
        {
            Users = new HashSet<User>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Int64? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Int64? UpdatedBy { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}