using System;
using System.Collections.Generic;
using System.Text;

namespace Tawjeeh.EntityModel
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }

    }
}
