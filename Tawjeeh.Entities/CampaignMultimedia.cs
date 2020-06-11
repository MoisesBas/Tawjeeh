using System;

namespace Tawjeeh.Entities
{
    public class CampaignMultimedia
    {
        public Int64? Id { get; set; }
        public Int64 CampaignId { get; set; }
        public int Type { get; set; }
        public Int64 SubTypeId { get; set; }
        public Int64 MultimediaId { get; set; }
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public string VideoUrl { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Int64? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Int64? UpdatedBy { get; set; }
    }
}
