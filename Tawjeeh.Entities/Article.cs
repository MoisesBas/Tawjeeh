using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace Tawjeeh.Entities
{ 
    [Table("tblArticle")]
    public class Article
    {
        public Article()
        {
            MultimediaArticles = new List<ArticleMultimedia>();
            ArticleTranslation = new List<ArticleTrans>();
            Decisions = new List<Decision>();
        }
        [Key]
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public string ArticleNo { get; set; }
        public string Description { get; set; }
        [Write(false)]
        public IList<ArticleTrans> ArticleTranslation { get; set; }
        [Write(false)]
        public IList<ArticleMultimedia> MultimediaArticles { get; set; }
        [Write(false)]
        public IList<Decision> Decisions { get; set; }
        public Int64? LawId { get; set; }
        public bool IsActive { get; set; }       
        public bool IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Int64? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Int64? UpdatedBy { get; set; }
    }
}
