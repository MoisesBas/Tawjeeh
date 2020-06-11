using Tawjeeh.Entities;
using Tawjeeh.Infrastructure;
using Tawjeeh.Repositories.Interface;

namespace Tawjeeh.Repositories.Repository
{
    public class ArticleMultimediaAuditTrailRepository : BaseRepository<ArticleMultimediaAuditTrail>, 
        IArticleMultimediaAuditTrailRepository
    {   
            public ArticleMultimediaAuditTrailRepository(IConnectionFactory connectionFactory) :
            base(connectionFactory)
        {

        }

        public int SetView(ArticleMultimediaAuditTrail auditTrail)
        {
            return base.Create(auditTrail);
        }
        public int LikeView(ArticleMultimediaAuditTrail auditTrail)
        {
            return base.Update(auditTrail);
        }
    }
}
