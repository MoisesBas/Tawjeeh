using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tawjeeh.Entities;

namespace Tawjeeh.Repositories.Interface
{
    public interface IArticleTransRepository
    {
        int CreateArticleTrans(ArticleTrans article);
        int DeleteArticleTrans(ArticleTrans article);
        int UpdateArticleTrans(ArticleTrans article);
        Task<IEnumerable<ArticleTrans>> GetArticleAllTrans();
        ArticleTrans GetArticleTransById(int id);
        ArticleTrans GetArticleTransLangIdAndId(long id, int langId);
        ArticleTrans GetArticleLangIdAndArticleId(long articleId, int langId);
        ArticleTrans GetArticleTransByName(Int64 articleId, string name, int langId);       
        IList<ArticleTrans> GetArticleByLawIdAndLangId(long lawId, int langId);
        IList<ArticleTrans> GetArticleByLangId(int langId);
    }
}
