using System;
namespace Tawjeeh.EntityModel
{
    public partial class CenterContacts:BaseEntity
    {
        
        public Int64? CenterId { get; set; }      
        public Int64? UserId { get; set; }      
        public virtual Centers Centers { get; set; }
        public virtual User User { get; set; }
        public long? ContactTypeId { get; set; }      
        public virtual ContactType ContactType { get; set; }
    }
}

