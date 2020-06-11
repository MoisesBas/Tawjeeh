using System;

namespace Tawjeeh.EntityModel
{
  public partial  class ArticleTrans: BaseEntity
    {  
        public string Name { get; set; }     
        public string Description { get; set; }
        public long? ArticleId { get; set; }        
        public string ArticleNo { get; set; }
        public int? LangId { get; set; }       
        public virtual Article Article { get; set; }
        
    }
}
