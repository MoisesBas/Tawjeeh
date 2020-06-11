using System;
using System.Collections.Generic;
using System.Text;

namespace Tawjeeh.EntityModel
{
  public partial  class InitiativeCampaign:BaseEntity
    {       
        public long? CampaignId { get; set; }
        public long? InitiativeId { get; set; }
        public DateTime? StartDateTime { get; set; }
        public string Result { get; set; }
        public string EvidenceResult { get; set; }
        public string EvidenceName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
        public string Target { get; set; }       
        public virtual Campaign Campaign { get; set; }
        public virtual Initiative Initiative { get; set; }
    }
}
