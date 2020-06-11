using System;
using System.Collections.Generic;
using Tawjeeh.EntityModel;

namespace Tawjeeh.Api.Models
{
    public class AddUpdateInitiativeViewModel
    {
        public Int64 Id { get; set; }
        public Int64? InitiativeTypeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<InitiativeCampaign> InitiativeCampaign { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Int64? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Int64? UpdatedBy { get; set; }
     
    }
}