using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace Tawjeeh.Entities
{
    [Table("tblAccessControls")]
    public class MenuAccess
    {
        [Key]
        public Int64 Id { get; set; }
        public Int64 UserId { get; set; }
        public Int64 MenuId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsAllowed { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Int64? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Int64? UpdatedBy { get; set; }
        [Write(false)]
        public Menu Menu { get; set; }
        [Write(false)]
        public User User {get;set;}
    }
}
