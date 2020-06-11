using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tawjeeh.Api.Models
{
    public class AddUpdateContactType
    {
        public AddUpdateContactType()
        {
            IsActive = true;
            IsDeleted = false;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }      
        public Int64? CreatedBy { get; set; }        
        public Int64? UpdatedBy { get; set; }
    }
}