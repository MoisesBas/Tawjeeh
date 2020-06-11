using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tawjeeh.EntityModel;

namespace Tawjeeh.Api.Models
{
    public class AddUpdateCampaignViewModel
    {
        public AddUpdateCampaignViewModel()
        {
            CampaignDetails = new List<CampaignDetail>();
            Goals = new List<Goal>();
        }
        public Int64 Id { get; set; }
        public string Title { get; set; }
        public Int32 Target { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int CampaignStatus { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public Int64? Budget { get; set; }
        public IEnumerable<CampaignDetail> CampaignDetails { get; set; }
        public IEnumerable<Goal> Goals { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Int64? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Int64? UpdatedBy { get; set; }
    }
}