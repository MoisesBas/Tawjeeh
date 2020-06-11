using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Tawjeeh.Api.Common;
using Tawjeeh.Api.Models;
using Tawjeeh.EntityModel;
using Tawjeeh.EntityModel.ReadOnly;
using Tawjeeh.EntityServices.Interface;
using Tawjeeh.Infrastructure;

namespace Tawjeeh.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Tawjeeh.Api.Controllers.BaseController" />
    [RoutePrefix("articles")]
    public class ArticlesController : BaseController
    {
        /// <summary>
        /// The path
        /// </summary>
        private static string[] path = Utilities.ArticlefilePath.Split(new char[] { '\\' });
        /// <summary>
        /// Initializes a new instance of the <see cref="ArticlesController"/> class.
        /// </summary>
        /// <param name="_serviceFactory">The service factory.</param>
        /// <param name="_sms">The SMS.</param>
        public ArticlesController(IServiceFactory _serviceFactory,ISms _sms)
           : base(_serviceFactory,_sms)
        {

        }

        /// <summary>
        /// Gets the article by law identifier.
        /// </summary>
        /// <param name="lawId">The law identifier.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("GetArticleByLawId")]
        [HttpGet]
        [ResponseType(typeof(IList<Article>))]
        public IHttpActionResult GetArticleByLawId(long lawId)
        {
            Guard.NotDefault(lawId, "law id is required.,");
            var result = _serviceFactory.CreateArticleService.GetArticleByLawId(lawId).ToList();
            if (result.Count > 0)
            {
                result.ToList().ForEach(x =>
                {
                    if (x.MultimediaArticles.Count > 0)
                    {
                        x.MultimediaArticles.ToList().ForEach(y =>
                        {
                            y.FileUrl = string.IsNullOrEmpty(y.FileUrl) ? string.Empty : "/" + path[path.Length - 2] + "/" + path[path.Length - 1] + "/" + y.FileUrl.TrimStart('/');
                        });
                    }
                });
            }
            return Ok(result);
        }
        /// <summary>
        /// Gets the article by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("GetArticleById")]
        [HttpGet]
        [ResponseType(typeof(Article))]
        public IHttpActionResult GetArticleById(int id)
        {
            Guard.NotDefault(id, "Article Id is null");
            var result = _serviceFactory.CreateArticleService.GetArticleById(id);
            if (result != null)
            {
                if (result.MultimediaArticles.Count > 0)
                {
                    result.MultimediaArticles.ToList().ForEach(x =>
                    {
                        x.FileUrl = string.IsNullOrEmpty(x.FileUrl) ? string.Empty : "/" + path[path.Length - 2] + "/" + path[path.Length - 1] + "/" + x.FileUrl.TrimStart('/');
                    });
                }
            }
            return Ok(result);
        }
        /// <summary>
        /// Gets the article language identifier and article identifier.
        /// </summary>
        /// <param name="articleId">The article identifier.</param>
        /// <param name="langId">The language identifier.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("GetArticleLangIdAndArticleId")]
        [HttpGet]
        [ResponseType(typeof(ArticleTrans))]
        public IHttpActionResult GetArticleLangIdAndArticleId(long articleId, int langId)
        {
            Guard.NotDefault(articleId, nameof(articleId));
            Guard.NotDefault(langId, nameof(langId));
            var result = _serviceFactory.CreateArticleService.GetArticleLangIdAndArticleId(articleId, langId);           
            return Ok(result);
        }
        /// <summary>
        /// Deletes the article.
        /// </summary>
        /// <param name="article">The article.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("DeleteArticles")]
        [HttpPut]
        [ResponseType(typeof(AddUpdateArticle))]
        public IHttpActionResult DeleteArticle(AddUpdateArticle article)
        {
            Guard.NotNull(article, "article is null");
            Guard.NotNullOrEmpty(article.Name, "article name is required.,");
            Guard.NotNullOrEmpty(article.Description, "article description is required.,");
            Guard.NotDefault(article.LawId, "article law is required.,");

            var map = AutoMapper.Mapper.Map<Article>(article);
            var result = _serviceFactory.CreateArticleService.DeleteArticle(map);
            return Ok(result);
        }
        /// <summary>
        /// Gets the article by language identifier.
        /// </summary>
        /// <param name="langId">The language identifier.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("GetArticleByLangId")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<ArticleTransReadOnly>))]
        public IHttpActionResult GetArticleByLangId(int langId)
        {
            Guard.NotDefault(langId, "langId is required.,");
            var result = _serviceFactory.CreateArticleService.GetArticleByLangId(langId);
            return Ok(result);
        }
        /// <summary>
        /// Gets the multimedia top video by language identifier.
        /// </summary>
        /// <param name="langId">The language identifier.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("GetMultimediaTopVideoByLangId")]
        [HttpGet]
        [ResponseType(typeof(MultimediaTopVideoReadOnly))]
        public IHttpActionResult GetMultimediaTopVideoByLangId(int langId)
        {
            Guard.NotDefault(langId, "Lang Id is required.");
            var result = _serviceFactory.CreateArticleService.GetMultimediaTopVideoByLangId(langId);
            if (result.RecentVideo != null)
            {
                if (result.RecentVideo.Count() > 0)
                {
                    result.RecentVideo.ToList().ForEach(x =>
                    {
                        x.FileUrl = string.IsNullOrEmpty(x.FileUrl) ? string.Empty : "/" + path[path.Length - 2] + "/" + path[path.Length - 1] + "/" + x.FileUrl.TrimStart('/');
                    });
                }
                result.TopVideo.FileUrl = result.TopVideo == null ? string.Empty : "/" + path[path.Length - 2] + "/" + path[path.Length - 1] + "/" + result.TopVideo.FileUrl.TrimStart('/');
            }
            return Ok(result);
        }
        /// <summary>
        /// Updates the articles.
        /// </summary>
        /// <param name="articleTrans">The article trans.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("AddUpdateArticleTrans")]
        [HttpPut]
        [ResponseType(typeof(AddUpdateArticleTrans))]
        public IHttpActionResult UpdateArticles(AddUpdateArticleTrans articleTrans)
        {
            Guard.NotNull(articleTrans, "article is null");
            Guard.NotNullOrEmpty(articleTrans.Name, "article name is required.,");
            Guard.NotNullOrEmpty(articleTrans.Description, "article description is required.,");
            Guard.NotDefault(articleTrans.LangId, "article language is required.,");
            Guard.NotDefault(articleTrans.ArticleId, "article Id is required.,");

            var map = AutoMapper.Mapper.Map<ArticleTrans>(articleTrans);
            var result = _serviceFactory.CreateArticleService.InsertUpdateArticleTrans(map);

            return Ok(result);
        }

        /// <summary>
        /// Uploads the article multimedia.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="HttpResponseException"></exception>
        /// <exception cref="Exception">
        /// File Type is required.,
        /// or
        /// Language Id is required.,
        /// or
        /// Decision Id is required.,
        /// or
        /// File Name is required.,
        /// </exception>
        [AllowAnonymous]
        [HttpPost]
        [Route("UploadArticleMultimedia")]
        public async Task<IHttpActionResult> UploadArticleMultimedia()
        {
            string articlefilePath = Utilities.IsProduction == true ? Utilities.ArticlefilePathProd : Utilities.ArticlefilePathDev;

            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.UnsupportedMediaType));
            }

            var UploadFilePath = CreateContractFile();
            StreamProvider streamProvider = new StreamProvider(UploadFilePath);
            var result = await Request.Content.ReadAsMultipartAsync(streamProvider);
            IEnumerable<string> FileDataNames = streamProvider.FileData.Select
                (entry => entry.LocalFileName.Replace(articlefilePath, ""));

            string _FileName = "";
            foreach (string value in FileDataNames)
                _FileName = value.Replace("\\", "//");

            if (Convert.ToInt32(result.FormData.GetValues("FileType")[0]) == 0)
                throw new Exception("File Type is required.,");

            if (Convert.ToInt32(result.FormData.GetValues("LangId")[0]) == 0)
                throw new Exception("Language Id is required.,");

            if (Convert.ToInt64(result.FormData.GetValues("ArticleId")[0]) == 0)
                throw new Exception("Decision Id is required.,");

            if (String.IsNullOrEmpty(Convert.ToString(result.FormData.GetValues("FileName")[0])))
                throw new Exception("File Name is required.,");


            var decisionmodel = new AddUpdateArticleMultimedia();
            decisionmodel.FileName = result.FormData.GetValues("FileName")[0];
            decisionmodel.FileType = Convert.ToInt32(result.FormData.GetValues("FileType")[0]);
            decisionmodel.ArticleId = Convert.ToInt64(result.FormData.GetValues("ArticleId")[0]);
            decisionmodel.LangId = Convert.ToInt32(result.FormData.GetValues("LangId")[0]);
            decisionmodel.VideoUrl = Convert.ToInt32(result.FormData.GetValues("FileType")[0]) != 1
            ? string.Empty : result.FormData.GetValues("VideoUrl")[0];
            decisionmodel.FileUrl = _FileName;

            var map = AutoMapper.Mapper.Map<ArticleMultimedia>(decisionmodel);
            var output = _serviceFactory.CreateArticleService.InsertOrUpdateArticleMultimedia(map);
            return Ok(output);
        }

        /// <summary>
        /// Deletes the article multimedia.
        /// </summary>
        /// <param name="articleMultimedia">The article multimedia.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("DeleteArticleMultimedia")]
        [HttpPut]
        [ResponseType(typeof(ArticleMultimedia))]
        public IHttpActionResult DeleteArticleMultimedia(ArticleMultimedia articleMultimedia)
        {
            var result = _serviceFactory.CreateArticleService.DeleteArticleMultimedia(articleMultimedia);
            return Ok(result);
        }
        /// <summary>
        /// Creates the contract file.
        /// </summary>
        /// <returns></returns>
        public string CreateContractFile()
        {
            string articlefilePath = Utilities.IsProduction == true ? Utilities.ArticlefilePathProd : Utilities.ArticlefilePathDev;
            DirectoryInfo DirInfo = new DirectoryInfo(articlefilePath);
            DirectorySecurity DirPermission = new DirectorySecurity();
            FileSystemAccessRule FRule = new FileSystemAccessRule("Everyone", FileSystemRights.ReadAndExecute, AccessControlType.Allow);
            DirPermission.AddAccessRule(FRule);
            if (!DirInfo.Exists)
            {
                Directory.CreateDirectory(articlefilePath);
            }

            return articlefilePath;
        }

        /// <summary>
        /// Sets the article media status.
        /// </summary>
        /// <param name="multimediaId">The multimedia identifier.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("SetArticleMediaStatus")]
        [HttpPut]
        [ResponseType(typeof(bool))]
        public IHttpActionResult SetArticleMediaStatus(long multimediaId)
        {
            Guard.NotDefault(multimediaId, "Article multimedia is required.,");
            var result = _serviceFactory.CreateArticleService.SetArticleMediaStatus(multimediaId);
            return Ok(result);
        }

        /// <summary>
        /// Sets the article multimedia like.
        /// </summary>
        /// <param name="mediaId">The media identifier.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("SetArticleMultimediaLike")]
        [HttpPut]
        [ResponseType(typeof(int))]
        public IHttpActionResult SetArticleMultimediaLike(Int64 mediaId)
        {
            var result = _serviceFactory.CreateArticleService.SetLike(mediaId);
            return Ok(result);
        }

        /// <summary>
        /// Sets the article multimedia view.
        /// </summary>
        /// <param name="mediaId">The media identifier.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("SetArticleMultimediaView")]
        [HttpPut]
        [ResponseType(typeof(int))]
        public IHttpActionResult SetArticleMultimediaView(Int64 mediaId)
        {
            var result = _serviceFactory.CreateArticleService.SetViewMultimedia(mediaId);
            return Ok(result);
        }

        /// <summary>
        /// Sets the article multimedia dis like.
        /// </summary>
        /// <param name="mediaId">The media identifier.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("SetArticleMultimediaDisLike")]
        [HttpPut]
        [ResponseType(typeof(int))]
        public IHttpActionResult SetArticleMultimediaDisLike(Int64 mediaId)
        {
            var result = _serviceFactory.CreateArticleService.SetDisLike(mediaId);
            return Ok(result);
        }

        /// <summary>
        /// Gets the article all.
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("GetArticleAll")]
        [HttpGet]
        [ResponseType(typeof(IList<Article>))]
        public IHttpActionResult GetArticleAll()
        {
            var result = _serviceFactory.CreateArticleService.GetArticleAll();
            if (result.Count() > 0)
            {
                result.ToList().ForEach(x =>
                {
                    if (x.MultimediaArticles.Count() > 0)
                    {
                        x.MultimediaArticles.ToList().ForEach(y =>
                        {
                            y.FileUrl = string.IsNullOrEmpty(y.FileUrl) ? string.Empty : "/" + path[path.Length - 2] + "/" + path[path.Length - 1] + "/" + y.FileUrl.TrimStart('/');
                        });
                    }
                });
            }
            return Ok(result);
        }
    }
}
