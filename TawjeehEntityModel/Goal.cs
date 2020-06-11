namespace Tawjeeh.EntityModel
{
    public partial class Goal:BaseEntity
    {       
        public long CampaignId { get; set; }
        public string Objective { get; set; }
        public string Target { get; set; }
        public string Actual { get; set; }
        public virtual Campaign Campaign { get; set; }

    }
}
