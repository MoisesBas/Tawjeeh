
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
    [RoutePrefix("decisions")]
    public class DecisionController : BaseController
    {
        /// <summary>
        /// The path
        /// </summary>
        private static string[] path = Utilities.DecisionfilePath.Split(new char[] { '\\' });
        /// <summary>
        /// Initializes a new instance of the <see cref="DecisionController"/> class.
        /// </summary>
        /// <param name="_serviceFactory">The service factory.</param>
        /// <param name="_sms">The SMS.</param>
        public DecisionController(IServiceFactory _serviceFactory,ISms _sms)
         : base(_serviceFactory,_sms)
        {

        }
        /// <summary>
        /// Gets the decision by article identifier and language identifier.
        /// </summary>
        /// <param name="articleId">The article identifier.</param>
        /// <param name="langId">The language identifier.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("GetDecisionByArticleIdAndLangId")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<DecisionReadOnly>))]
        public IHttpActionResult GetDecisionByArticleIdAndLangId(long articleId, int langId)
        {
            Guard.NotDefault(articleId, "Article Id is required.,");
            Guard.NotDefault(langId, "Language Id is required.,");
            var result = _serviceFactory.CreateDecisionService.GetDecisionByArticleIdAndLangId(articleId, langId);
            if (result != null)
            {
                result.ToList().ForEach(x =>
                {
                    if (x.MultimediaDecisions.Count() > 0)
                    {
                        x.MultimediaDecisions.ToList().ForEach(y =>
                        {
                            y.FileUrl = string.IsNullOrEmpty(y.FileUrl) ? string.Empty : "/" + path[path.Length - 2] + "/" + path[path.Length - 1] + "/" + y.FileUrl.TrimStart('/');
                        });
                    }
                });
            }
            
            return Ok(result);
        }
        /// <summary>
        /// Getdecisions the trans language identifier and decision identifier.
        /// </summary>
        /// <param name="decisionId">The decision identifier.</param>
        /// <param name="langId">The language identifier.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("GetdecisionTransLangIdAndDecisionId")]
        [HttpGet]
        [ResponseType(typeof(DecisionTransReadOnly))]
        public IHttpActionResult GetdecisionTransLangIdAndDecisionId(long decisionId, int langId)
        {
            var result = _serviceFactory.CreateDecisionService.GetdecisionTransLangIdAndDecisionId(decisionId, langId);
            return Ok(result);
        }

        /// <summary>
        /// Gets the decision by article identifier.
        /// </summary>
        /// <param name="articleId">The article identifier.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("GetDecisionByArticleId")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<DecisionReadOnly>))]
        public IHttpActionResult GetDecisionByArticleId(long articleId)
        {
            Guard.NotDefault(articleId, "Article Id is required.,");
            var result = _serviceFactory.CreateDecisionService.GetDecisionByArticleId(articleId).ToList();
            if (result.Count > 0)
            {
                result.ToList().ForEach(x =>
                {
                    if (x.MultimediaDecisions.Count() > 0)
                    {
                        x.MultimediaDecisions.ToList().ForEach(y =>
                        {
                            y.FileUrl = string.IsNullOrEmpty(y.FileUrl) ? string.Empty : "/" + path[path.Length - 2] + "/" + path[path.Length - 1] + "/" + y.FileUrl.TrimStart('/');
                        });
                    }
                });
            }
            return Ok(result);
        }

        /// <summary>
        /// Creates the specified decision.
        /// </summary>
        /// <param name="decision">The decision.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("AddUpdateDecision")]
        [HttpPut]
        [ResponseType(typeof(AddUpdateDecisionViewModel))]
        public IHttpActionResult Create(AddUpdateDecisionViewModel decision)
        {
            Guard.NotNull(decision, "Decision object is null.,");
            var map = AutoMapper.Mapper.Map<Decision>(decision);
            Guard.NotNullOrEmpty(map.Name, "Decision Name is required.,");
            Guard.NotDefault(map.ArticleId, "Article Id is required.,");

            var result = _serviceFactory.CreateDecisionService.InsertOrUpdateDecision(map);
            return Ok(result);
        }
        /// <summary>
        /// Gets the decision by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("GetDecisionById")]
        [HttpGet]
        [ResponseType(typeof(Decision))]
        public IHttpActionResult GetDecisionById(long id)
        {
            var result = _serviceFactory.CreateDecisionService.GetDecisionById(id);
            return Ok(result);
        }

        /// <summary>
        /// Creates the specified decision translation.
        /// </summary>
        /// <param name="decisionTranslation">The decision translation.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("AddUpdateDecisionTranslation")]
        [HttpPut]
        [ResponseType(typeof(AddUpdateDecisionTranslationViewModel))]
        public IHttpActionResult Create(AddUpdateDecisionTranslationViewModel decisionTranslation)
        {
            Guard.NotNull(decisionTranslation, "Decision translation object is null.,");
            var map = AutoMapper.Mapper.Map<DecisionTrans>(decisionTranslation);
            Guard.NotNullOrEmpty(map.Name, "Decision Translation Name is required.,");
            Guard.NotDefault(map.ArticleId, "Article Id is required.,");
            Guard.NotDefault(map.LangId, "Language Id is required.,");
            Guard.NotDefault(map.DecisionId, "Decision Id is required");

            var result = _serviceFactory.CreateDecisionService.InsertOrUpdateDecisionTrans(map);
            return Ok(result);
        }

        /// <summary>
        /// Gets the decision multimedia by decision multimedia identifier.
        /// </summary>
        /// <param name="decisionId">The decision identifier.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("GetDecisionMultimediaByDecisionMultimediaId")]
        [HttpGet]
        [ResponseType(typeof(IList<DecisionMultimedia>))]
        public IHttpActionResult GetDecisionMultimediaByDecisionMultimediaId(long decisionId)
        {
            var result = _serviceFactory.CreateDecisionService.GetDecisionMultimediaByDecisionMultimediaId(decisionId).ToList();
            if (result.Count > 0)
            {
                result.ToList().ForEach(x =>
                {
                    x.FileUrl = string.IsNullOrEmpty(x.FileUrl) ? string.Empty : "/" + path[path.Length - 2] + "/" + path[path.Length - 1] + "/" + x.FileUrl.TrimStart('/');
                });
            }
            return Ok(result);
        }

        /// <summary>
        /// Sets the decision multimedia status.
        /// </summary>
        /// <param name="decisionId">The decision identifier.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("SetDecisionMultimediaStatus")]
        [HttpPut]
        [ResponseType(typeof(bool))]
        public IHttpActionResult SetDecisionMultimediaStatus(long decisionId)
        {
            Guard.NotDefault(decisionId, "Decision multimedia id is null.,");
            var result = _serviceFactory.CreateDecisionService.SetDecisionMultimediaStatus(decisionId);
            return Ok(result);
        }

        /// <summary>
        /// Uploads the decision multimedia.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="HttpResponseException"></exception>
        /// <exception cref="Exception">
        /// File Type is required.,
        /// or
        /// Language Id is required.,
        /// or
        /// Decision Id is required.,
        /// </exception>
        [AllowAnonymous]
        [HttpPost]
        [Route("UploadDecisionMultimedia")]
        public async Task<IHttpActionResult> UploadDecisionMultimedia()
        {
            string decisionfilePath = Utilities.DecisionfilePath;
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.UnsupportedMediaType));
            }

            var UploadFilePath = CreateContractFile();
            StreamProvider streamProvider = new StreamProvider(UploadFilePath);
            var result = await Request.Content.ReadAsMultipartAsync(streamProvider);
            IEnumerable<string> FileDataNames = streamProvider.FileData.Select
                (entry => entry.LocalFileName.Replace(decisionfilePath, ""));
            string _FileName = "";
            foreach (string value in FileDataNames)
                _FileName = value.Replace("\\", "//");

            if (Convert.ToInt32(result.FormData.GetValues("FileType")[0]) == 0)
                throw new Exception("File Type is required.,");

            if (Convert.ToInt32(result.FormData.GetValues("LangId")[0]) == 0)
                throw new Exception("Language Id is required.,");

            if (Convert.ToInt64(result.FormData.GetValues("DecisionId")[0]) == 0)
                throw new Exception("Decision Id is required.,");


            var decisionmodel = new AddUpdateDecisionMultimediaViewModel
            {
                FileName = result.FormData.GetValues("FileName")[0],
                FileType = Convert.ToInt32(result.FormData.GetValues("FileType")[0]),
                DecisionId = Convert.ToInt64(result.FormData.GetValues("DecisionId")[0]),
                LangId = Convert.ToInt32(result.FormData.GetValues("LangId")[0]),
                VideoUrl = Convert.ToInt32(result.FormData.GetValues("FileType")[0]) != 1 ?
                string.Empty : result.FormData.GetValues("VideoUrl")[0],
                FileUrl = _FileName
            };

            var map = AutoMapper.Mapper.Map<DecisionMultimedia>(decisionmodel);
            var output = _serviceFactory.CreateDecisionService.InsertOrUpdateDecisionMultimedia(map);
            return Ok(output);
        }

        /// <summary>
        /// Gets all decisions.
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("GetAllDecisions")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<DecisionReadOnly>))]
        public IHttpActionResult GetAllDecisions()
        {
            var result = _serviceFactory.CreateDecisionService.GetDecisionAlls();
            if (result.Count() > 0)
            {
                result.ToList().ForEach(x =>
                {
                    x.MultimediaDecisions.ToList().ForEach(y =>
                    {
                        y.FileUrl = string.IsNullOrEmpty(y.FileUrl) ? string.Empty : "/" + path[path.Length - 2] + "/" + path[path.Length - 1] + "/" + y.FileUrl.TrimStart('/');
                    });
                });
            }
            return Ok(result);
        }
        /// <summary>
        /// Creates the contract file.
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public string CreateContractFile()
        {

            string UploadFilePath = Utilities.DecisionfilePath;
            DirectoryInfo DirInfo = new DirectoryInfo(UploadFilePath);
            DirectorySecurity DirPermission = new DirectorySecurity();
            FileSystemAccessRule FRule = new FileSystemAccessRule("Everyone", FileSystemRights.ReadAndExecute, AccessControlType.Allow);
            DirPermission.AddAccessRule(FRule);
            if (!DirInfo.Exists)
            {
                Directory.CreateDirectory(UploadFilePath);
            }

            return UploadFilePath;
        }
    }
}
