using System;
using System.Collections.Generic;
using System.Text;

namespace Tawjeeh.EntityModel
{
  public  class CampaignDetail:BaseEntity
    {
        public CampaignDetail()
        {
            CampaignDocuments = new HashSet<CampaignDocument>();
        }     
        public long? CampaignId { get; set; }
        public int? Type { get; set; }
        public long? SubTypeId { get; set; }
        public long? MultimediaId { get; set; }
        public string Others { get; set; }        
        public virtual Campaign Campaign { get; set; }
        public virtual ICollection<CampaignDocument> CampaignDocuments { get; set; }
    }
}
