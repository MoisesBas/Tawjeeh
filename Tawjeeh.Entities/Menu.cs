﻿using Dapper.Contrib.Extensions;
using System;

namespace Tawjeeh.Entities
{
    [Table("tblMenu")]
    public class Menu
    {
        [Key]
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Int64 CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Int64? UpdatedBy { get; set; } 
    }
}