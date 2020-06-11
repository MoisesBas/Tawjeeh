using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Web;
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
    [RoutePrefix("campaign")]
    public class CampaignController : BaseController
    {
        /// <summary>
        /// The path
        /// </summary>
        private static string[] path = Utilities.CampaignfilePath.Split(new char[] { '\\' });
        /// <summary>
        /// The path article
        /// </summary>
        private static string[] pathArticle = Utilities.ArticlefilePath.Split(new char[] { '\\' });
        /// <summary>
        /// The path decision
        /// </summary>
        private static string[] pathDecision = Utilities.DecisionfilePath.Split(new char[] { '\\' });
        /// <summary>
        /// The path law
        /// </summary>
        private static string[] pathLaw = Utilities.LawfilePath.Split(new char[] { '\\' });
        /// <summary>
        /// The path initiative
        /// </summary>
        private static string[] pathInitiative = Utilities.InitiativePath.Split(new char[] { '\\' });
        /// <summary>
        /// Initializes a new instance of the <see cref="CampaignController"/> class.
        /// </summary>
        /// <param name="_serviceFactory">The service factory.</param>
        /// <param name="_sms">The SMS.</param>
        public CampaignController(IServiceFactory _serviceFactory,ISms _sms)
           : base(_serviceFactory,_sms)
        {

        }

        /// <summary>
        /// Gets the campaign all.
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("GetCampaignAll")]
        [HttpGet]
        [ResponseType(typeof(IList<Campaign>))]
        public IHttpActionResult GetCampaignAll()
        {
            var result = _serviceFactory.CreateCampaignService.GetCampaignAll();
            return Ok(result);
        }

        /// <summary>
        /// Gets the campaign by identifier.
        /// </summary>
        /// <param name="campId">The camp identifier.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("GetCampaignById")]
        [HttpGet]
        [ResponseType(typeof(Campaign))]
        public IHttpActionResult GetCampaignById(long campId)
        {
            var result = _serviceFactory.CreateCampaignService.GetCampaignById(campId);

            if (result != null)
            {
                if (result.CampaignMultimedia.Count() > 0)
                {
                    result.CampaignMultimedia.ToList().ForEach(x =>
                    {
                        x.FileUrl = string.IsNullOrEmpty(x.FileUrl) ? string.Empty : "/" + path[path.Length - 2] + "/" + path[path.Length - 1] + "/" + x.FileUrl.TrimStart('/');
                    });
                }
            }
            return Ok(result);
        }

        /// <summary>
        /// Updates the campaign.
        /// </summary>
        /// <param name="campaign">The campaign.</param>
        /// <returns></returns>
        /// <exception cref="Exception">
        /// Invalid Date Time Format in Campaign From Date.
        /// or
        /// Invalid Date Time Format in Campaign To Date.
        /// or
        /// Campaign To Date must be greater than Campaign From Date.,
        /// or
        /// Invalid Target for campaign.,
        /// </exception>
        [AllowAnonymous]
        [Route("AddUpdateCampaign")]
        [HttpPut]
        [ResponseType(typeof(AddUpdateCampaignViewModel))]
        public IHttpActionResult UpdateCampaign(AddUpdateCampaignViewModel campaign)
        {
            Guard.NotNull(campaign, nameof(campaign));
            Guard.NotNullOrEmpty(campaign.Title, "Campaing title is null");

            if (!DateTime.TryParse(campaign.FromDate.Value.ToString(), out DateTime from))
                throw new Exception("Invalid Date Time Format in Campaign From Date.");

            if (!DateTime.TryParse(campaign.ToDate.Value.ToString(), out DateTime to))
                throw new Exception("Invalid Date Time Format in Campaign To Date.");

            if (to <= from) throw new Exception("Campaign To Date must be greater than Campaign From Date.,");

            if (!Enum.IsDefined(typeof(GlobalEnum.Target), campaign.Target))
                throw new Exception("Invalid Target for campaign.,");

            var map = AutoMapper.Mapper.Map<Campaign>(campaign);
            var result = _serviceFactory.CreateCampaignService.InsertOrUpdateCampaign(map);
            return Ok(result);
        }

        /// <summary>
        /// Deletes the campaign.
        /// </summary>
        /// <param name="campaign">The campaign.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("DeleteCampaign")]
        [HttpPut]
        [ResponseType(typeof(int))]
        public IHttpActionResult DeleteCampaign(AddUpdateCampaignViewModel campaign)
        {
            Guard.NotDefault(campaign.Id, "Campaign Id null.,");
            var map = AutoMapper.Mapper.Map<Campaign>(campaign);
            map.UpdatedBy = 1;
            var result = _serviceFactory.CreateCampaignService.DeleteCampaign(map);
            return Ok(result);
        }

        /// <summary>
        /// Gets the initiative by campaign identifier.
        /// </summary>
        /// <param name="campId">The camp identifier.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("GetInitiativeByCampaignId")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Initiative>))]
        public IHttpActionResult GetInitiativeByCampaignId(int campId)
        {
            Guard.NotDefault(campId, "Campaign Id is null.,");
            var result = _serviceFactory.CreateInitiativeService.GetInitiativeByCampaignId(campId);
            return Ok(result);
        }

        /// <summary>
        /// Adds the update initiative.
        /// </summary>
        /// <param name="initiative">The initiative.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("AddUpdateInitiative")]
        [HttpPut]
        [ResponseType(typeof(AddUpdateInitiativeViewModel))]
        public IHttpActionResult AddUpdateInitiative(AddUpdateInitiativeViewModel initiative)
        {
            Guard.NotNull(initiative, nameof(initiative));
            Guard.NotNullOrEmpty(initiative.Title, "Initiative title is null");

            if (initiative.InitiativeCampaign != null)
            {
                if (initiative.InitiativeCampaign.Count() > 0)
                {
                    initiative.InitiativeCampaign.ToList().ForEach(x =>
                    {
                        if (!DateTime.TryParse(x.StartDate.Value.ToString(), out DateTime from))
                            throw new Exception("Invalid Date Time Format in Initiative Campaign From Date.");

                        if (!DateTime.TryParse(x.EndDate.Value.ToString(), out DateTime to))
                            throw new Exception("Invalid Date Time Format in Initiative Campaign  To Date.");

                        if (to <= from)
                            throw new Exception("Campaign To Date must be greater than Campaign From Date.,");
                    });

                }
            }
            var map = AutoMapper.Mapper.Map<Initiative>(initiative);
            var result = _serviceFactory.CreateInitiativeService.InsertOrUpdateInitiative(map);
            return Ok(result);
        }
        /// <summary>
        /// Deletes the initiative.
        /// </summary>
        /// <param name="iniId">The ini identifier.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("DeleteInitiative")]
        [HttpPut]
        [ResponseType(typeof(int))]
        public IHttpActionResult DeleteInitiative(Int64 iniId)
        {
            Guard.NotDefault(iniId, "Initiative Id is null.,");
            var result = _serviceFactory.CreateInitiativeService.DeleteInitiative(iniId);
            return Ok(result);
        }

        /// <summary>
        /// Gets the campaign multimedia by campaign identifier.
        /// </summary>
        /// <param name="campId">The camp identifier.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("GetCampaignMultimediaByCampaignId")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<CampaignMultimedia>))]
        public IHttpActionResult GetCampaignMultimediaByCampaignId(Int64 campId)
        {
            Guard.NotDefault(campId, "Campaign Id is null.,");
            var result = _serviceFactory.CreateCampaignService.GetCampaignMultimedia(campId);
            return Ok(result);
        }

        /// <summary>
        /// Uploads the initiative result.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="HttpResponseException"></exception>
        /// <exception cref="Exception">Id is required.</exception>
        [AllowAnonymous]
        [HttpPost]
        [Route("UploadInitiativeResult")]
        public async Task<IHttpActionResult> UploadInitiativeResult()
        {
            string UploadFilePath = string.Empty;

            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.UnsupportedMediaType));
            }

            UploadFilePath = UploadFile(GlobalEnum.CampaignType.Initiative);

            StreamProvider streamProvider = new StreamProvider(UploadFilePath);
            var result = await Request.Content.ReadAsMultipartAsync(streamProvider);
            IEnumerable<string> FileDataNames = streamProvider.FileData.Select
                (entry => entry.LocalFileName.Replace(Utilities.InitiativePath, ""));

            string _FileName = "";
            foreach (string value in FileDataNames)
                _FileName = value.Replace("\\", "//");
            if (Convert.ToUInt64(result.FormData.GetValues("Id")[0]) == 0)
                throw new Exception("Id is required.");

            var id = Convert.ToInt32(result.FormData.GetValues("Id")[0]);
            var documentTitle = result.FormData.GetValues("DocumentTitle")[0];

            var details = _serviceFactory.CreateInitiativeService.GetInitiativeCampaignById(id);
            Guard.NotNull(details, nameof(details));
            details.EvidenceName = result.FormData.GetValues("DocumentTitle")[0];
            details.EvidenceResult = _FileName;
            var output = _serviceFactory.CreateInitiativeService.InsertOrUpdateInitiativeCampaign(details);
            return Ok(output);
        }
        /// <summary>
        /// Uploads the file.
        /// </summary>
        /// <param name="campaignType">Type of the campaign.</param>
        /// <returns></returns>
        public string UploadFile(GlobalEnum.CampaignType campaignType)
        {
            string directoryPath = string.Empty;
            if (campaignType == GlobalEnum.CampaignType.Others)
                directoryPath = Utilities.CampaignfilePath;
            if (campaignType == GlobalEnum.CampaignType.Initiative)
                directoryPath = Utilities.InitiativePath;

            DirectoryInfo DirInfo = new DirectoryInfo(directoryPath);
            DirectorySecurity DirPermission = new DirectorySecurity();
            FileSystemAccessRule FRule = new FileSystemAccessRule("Everyone", FileSystemRights.ReadAndExecute, AccessControlType.Allow);
            DirPermission.AddAccessRule(FRule);
            if (!DirInfo.Exists)
            {
                Directory.CreateDirectory(directoryPath);
            }
            return directoryPath;
        }

        /// <summary>
        /// Uploads the campaign document multimedia.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="HttpResponseException"></exception>
        /// <exception cref="Exception">
        /// Campaign Id is required.,
        /// or
        /// Type is required.,
        /// or
        /// Document Title is required.,
        /// or
        /// Campaign Details is null.,
        /// </exception>
        [AllowAnonymous]
        [HttpPost]
        [Route("UploadCampaignMultimedia")]
        public async Task<IHttpActionResult> UploadCampaignDocumentMultimedia()
        {
            string campaignfilePath = string.Empty;
            string UploadFilePath = string.Empty;

            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.UnsupportedMediaType));
            }
            var type = Convert.ToInt32(HttpContext.Current.Request.Params["Type"]);
            Guard.NotDefault(type, "Type is required.,");

            UploadFilePath = UploadFile(GlobalEnum.CampaignType.Others);
            campaignfilePath = Utilities.IsProduction == true ? Utilities.CampaignfilePathProd : Utilities.CampaignfilePathDev;

            StreamProvider streamProvider = new StreamProvider(UploadFilePath);
            var result = await Request.Content.ReadAsMultipartAsync(streamProvider);
            IEnumerable<string> FileDataNames = streamProvider.FileData.Select
                (entry => entry.LocalFileName.Replace(campaignfilePath, ""));

            string _FileName = "";
            foreach (string value in FileDataNames)
                _FileName = value.Replace("\\", "//");


            if (Convert.ToInt64(result.FormData.GetValues("CampaignId")[0]) == 0)
                throw new Exception("Campaign Id is required.,");

            if (Convert.ToInt32(result.FormData.GetValues("Type")[0]) == 0)
                throw new Exception("Type is required.,");

            if (String.IsNullOrEmpty(Convert.ToString(result.FormData.GetValues("DocumentTitle")[0])))
                throw new Exception("Document Title is required.,");

            var campDoc = new CampaignMultimediaViewModel();
            campDoc.DocumentTitle = result.FormData.GetValues("DocumentTitle")[0];
            campDoc.DocumentPath = _FileName;
            campDoc.CampaignId = Convert.ToInt64(result.FormData.GetValues("CampaignId")[0]);
            campDoc.Type = Convert.ToInt32(result.FormData.GetValues("Type")[0]);
            campDoc.SubTypeId = Convert.ToInt64(result.FormData.GetValues("SubTypeId")[0]);
            var details = _serviceFactory.CreateCampaignService.GetCampaignDetailsByCampaignId(Convert.ToInt64(campDoc.CampaignId));
            if (details == null) throw new Exception("Campaign Details is null.,");

            var doc = AutoMapper.Mapper.Map<CampaignDocument>(campDoc);
            doc.CampaignDetailsId = details.Id;
            var output = _serviceFactory.CreateCampaignService.InsertOrUpdateCampaignDoc(doc);
            return Ok(output);
        }
    }

}
