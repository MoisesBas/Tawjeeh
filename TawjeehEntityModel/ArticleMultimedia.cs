using System;

namespace Tawjeeh.EntityModel
{ 
    public partial class ArticleMultimedia:BaseEntity
    {       
        public long? ArticleId { get; set; }
        public int? LangId { get; set; }       
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public string VideoUrl { get; set; }
        public int? FileType { get; set; }
        public long? CntLikes { get; set; }
        public long? CntDisLikes { get; set; }
        public long? CntViews { get; set; }       
        public string Description { get; set; }
        public bool? IsMobile { get; set; }     
        public virtual Article Article { get; set; }
    }
}
