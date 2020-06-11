using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tawjeeh.Api.Models
{
    public class CampaignMultimediaViewModel
    {
        public Int64 Id { get; set; }
        public Int64? CampaignId { get; set; }
        public int Type { get; set; }
        public Int64? SubTypeId { get; set; }
        public string DocumentTitle { get; set; }
        public string DocumentPath { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Int64? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Int64? UpdatedBy { get; set; }
    }
}