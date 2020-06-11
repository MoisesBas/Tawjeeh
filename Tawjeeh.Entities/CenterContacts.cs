using Dapper.Contrib.Extensions;
using System;

namespace Tawjeeh.Entities
{
    [Table("tblCenterContacts")]
    public class CenterContacts
    {
        public CenterContacts()
        {
            Users = new User();
        }
        [Key]
        public Int64 Id { get; set; }
        public Int64? CenterId { get; set; }
        public Int64? UserId { get; set; }
        [Write(false)]
        public User Users { get; set; }
        public int? ContactTypeId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Int64? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Int64? UpdatedBy { get; set; }

    }
}
