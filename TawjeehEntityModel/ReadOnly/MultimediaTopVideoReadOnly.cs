using System;
using System.Collections.Generic;
using System.Text;

namespace Tawjeeh.EntityModel.ReadOnly
{
   public class MultimediaTopVideoReadOnly
    {
        public MultimediaTopVideoReadOnly()
        {
            TopVideo = new ArticleMultimedia();
            RecentVideo = new List<ArticleMultimedia>();
            Article = new List<ArticleTrans>();
        }
        public ArticleMultimedia TopVideo { get; set; }
        public IEnumerable<ArticleMultimedia> RecentVideo { get; set; }
        public IEnumerable<ArticleTrans> Article { get; set; }
    }
}
