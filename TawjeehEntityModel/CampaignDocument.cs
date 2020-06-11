using System;
using System.Collections.Generic;
using System.Text;

namespace Tawjeeh.EntityModel
{
   public class CampaignDocument:BaseEntity
    {     
        public long? CampaignId { get; set; }
        public long? CampaignDetailsId { get; set; }
        public string DocumentTitle { get; set; }
        public string DocumentPath { get; set; }        
        public virtual CampaignDetail CampaignDetail { get; set; }
    }
}
