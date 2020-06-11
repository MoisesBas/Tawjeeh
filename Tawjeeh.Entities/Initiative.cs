using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace Tawjeeh.Entities
{
    [Table("tblInitiative")]
    public class Initiative
    {
        [Key]
        public Int64 Id { get; set; }
        public Int64? InitiativeTypeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [Write(false)]
        public InitiativeType InitiativeType { get; set; }
        [Write(false)]
        public IList<InitiativeCampaign> InitiativeCampaign { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Int64? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Int64? UpdatedBy { get; set; }
    }
}
