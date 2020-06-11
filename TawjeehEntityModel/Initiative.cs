using System;
using System.Collections.Generic;
using System.Text;

namespace Tawjeeh.EntityModel
{
   public partial class Initiative:BaseEntity
    {
        public Initiative()
        {
            InitiativeCampaigns = new HashSet<InitiativeCampaign>();
        }
       
        public long? InitiativeTypeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }       
        public virtual InitiativeType InitiativeType { get; set; }
        public virtual ICollection<InitiativeCampaign> InitiativeCampaigns { get; set; }
    }
}
