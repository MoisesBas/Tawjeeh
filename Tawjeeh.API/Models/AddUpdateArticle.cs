using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tawjeeh.Api.Models
{
    public class AddUpdateArticle
    {
        public AddUpdateArticle()
        {
            IsActive = true;
            IsDeleted = false;
        }
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Int64? LawId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public Int64? CreatedBy { get; set; }      
        public Int64? UpdatedBy { get; set; }
      
    }
}