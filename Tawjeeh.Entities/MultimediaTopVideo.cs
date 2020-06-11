using System.Collections.Generic;

namespace Tawjeeh.Entities
{
    public class MultimediaTopVideo
    {
        public MultimediaTopVideo()
        {
            TopVideo = new ArticleMultimedia();
            RecentVideo = new List<ArticleMultimedia>();
            Article = new List<ArticleTrans>();
        }
        public ArticleMultimedia TopVideo { get; set; }
        public IList<ArticleMultimedia> RecentVideo { get; set; }
        public IList<ArticleTrans> Article { get; set; }
    }
}
