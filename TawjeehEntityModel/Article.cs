using System;
using System.Collections.Generic;
namespace Tawjeeh.EntityModel
{
  
    public partial class Article:BaseEntity
    {
       
        public Article()
        {
            MultimediaArticles = new HashSet<ArticleMultimedia>();
            Decisions = new HashSet<Decision>();
            ArticleTranslations = new HashSet<ArticleTrans>();           
        }  
      
        public string Name { get; set; }       
        public string Description { get; set; }
        public long? LawId { get; set; }       
        public string ArticleNo { get; set; } 
        public virtual Law Law { get; set; }      
        public virtual ICollection<ArticleTrans> ArticleTranslations { get; }        
        public virtual ICollection<Decision> Decisions { get; set; }
        public virtual ICollection<ArticleMultimedia> MultimediaArticles { get; set; }      

    }
}
