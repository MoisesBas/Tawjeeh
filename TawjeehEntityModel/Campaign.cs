using System;
using System.Collections.Generic;
using System.Text;

namespace Tawjeeh.EntityModel
{
   public partial class Campaign:BaseEntity
    {
        public Campaign()
        {
            CampaignDetails = new HashSet<CampaignDetail>();
            InitiativeCampaigns = new HashSet<InitiativeCampaign>();
            Goals = new HashSet<Goal>();
        }
        public string Title { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int Target { get; set; }
        public int CampaignStatus { get; set; }
        public long? Budget { get; set; }
        public virtual ICollection<CampaignDetail> CampaignDetails { get; set; }
        public virtual ICollection<InitiativeCampaign> InitiativeCampaigns { get; set; }
        public virtual ICollection<Goal> Goals { get; set; }


    }
}
