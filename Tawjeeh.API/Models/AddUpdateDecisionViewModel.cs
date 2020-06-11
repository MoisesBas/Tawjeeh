using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tawjeeh.Api.Models
{
    public class AddUpdateDecisionViewModel
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Int64? ArticleId { get; set; }
        public string DecisionNo { get; set; }
        public Int64? Year { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Int64? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Int64? UpdatedBy { get; set; }
    }
}