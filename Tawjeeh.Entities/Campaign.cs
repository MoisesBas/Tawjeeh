using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tawjeeh.Entities
{
    [Table("tblCampaign")]
    public class Campaign
    {
        public Campaign()
        {
            CampaignDetails = new List<CampaignDetails>();
            Goals = new List<Goal>();
            CampaignDocument = new List<CampaignDocument>();
            Initiative = new Initiative();
            CampaignMultimedia = new List<CampaignMultimedia>();
        }
        [Key]
        public Int64 Id { get; set; }
        public string Title { get; set; }
        public Int32 Target { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int CampaignStatus { get; set; }       
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public Int64? Budget { get; set; }
        [Write(false)]
        public IList<CampaignDetails> CampaignDetails { get; set; }
        [Write(false)]
        public IList<Goal> Goals { get; set; }
        [Write(false)]
        public IList<CampaignDocument> CampaignDocument { get; set; }
        [Write(false)]
      
        public Initiative Initiative { get; set; }
        [Write(false)]
        public IList<CampaignMultimedia> CampaignMultimedia { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Int64? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Int64? UpdatedBy { get; set; }


    }
}
