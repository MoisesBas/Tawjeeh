
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using Tawjeeh.Api.Models;
using Tawjeeh.EntityModel;
using Tawjeeh.EntityServices.Interface;
using Tawjeeh.Infrastructure;

namespace Tawjeeh.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Tawjeeh.Api.Controllers.BaseController" />
    [RoutePrefix("centers")]
    public class CentersController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CentersController"/> class.
        /// </summary>
        /// <param name="_serviceFactory">The service factory.</param>
        /// <param name="_sms">The SMS.</param>
        public CentersController(IServiceFactory _serviceFactory,ISms _sms)
            : base(_serviceFactory,_sms)
        {

        }

        /// <summary>
        /// Creates the specified center.
        /// </summary>
        /// <param name="center">The center.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("AddUpdateCenter")]
        [HttpPut]
        [ResponseType(typeof(AddUpdateCenterViewModel))]
        public IHttpActionResult Create(AddUpdateCenterViewModel center)
        {
            Guard.NotNull(center, "Center object is null.,");
            var map = AutoMapper.Mapper.Map<Centers>(center);
            Guard.NotNullOrEmpty(map.Name, "Centers Name is required.,");
            Guard.NotDefault(map.EmiratesId, "Emirates is required.,");

            var result = _serviceFactory.CreateCenterService.InsertOrUpdateCenters(map);
            return Ok(result);
        }

        /// <summary>
        /// Gets all centers.
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("GetAllCenters")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Centers>))]
        public IHttpActionResult GetAllCenters()
        {
            var result = _serviceFactory.CreateCenterService.GetAll();
            return Ok(result);
        }

        /// <summary>
        /// Deletes the specified center.
        /// </summary>
        /// <param name="center">The center.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("DeleteCenter")]
        [HttpPut]
        [ResponseType(typeof(AddUpdateCenterViewModel))]
        public IHttpActionResult Delete(AddUpdateCenterViewModel center)
        {
            Guard.NotNull(center, "Center parameters is null.,");
            Guard.NotDefault(center.Id, "Center Id is null.,");
            var map = _serviceFactory.CreateCenterService.GetCenterById(center.Id);
            Guard.NotNull(center, "Centers is not exists.,");
            var result = _serviceFactory.CreateCenterService.DeleteCenter(map);

            return Ok(result);
        }

        /// <summary>
        /// Gets the center by identifier and language identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="langId">The language identifier.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("GetCenterByIdAndLangId")]
        [HttpGet]
        [ResponseType(typeof(Centers))]
        public IHttpActionResult GetCenterByIdAndLangId(int id, int langId)
        {
            var result = _serviceFactory.CreateCenterService.GetCenterById(id, langId);
            return Ok(result);
        }


        /// <summary>
        /// Updates the center trans.
        /// </summary>
        /// <param name="centerTrans">The center trans.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("AddUpdateCenterTrans")]
        [HttpPut]
        [ResponseType(typeof(AddUpdateCenterTransViewModel))]
        public IHttpActionResult UpdateCenterTrans(AddUpdateCenterTransViewModel centerTrans)
        {
            Guard.NotNull(centerTrans, "Center Translation parameter is null.,");
            Guard.NotNullOrEmpty(centerTrans.Name, "Center Translation parameter is  empty.,");
            Guard.NotDefault(centerTrans.LangId, "Language Id  parameter is  empty.,");

            var map = AutoMapper.Mapper.Map<CenterTrans>(centerTrans);
            var centers = _serviceFactory.CreateCenterService.GetCenterById(Convert.ToInt32(map.CenterId));

            Guard.NotNull(centers, nameof(centers));
            map.EmiratesId = centers.EmiratesId;
            map.TradeLicense = centers.TradeLicense;
            map.TradeLicenseExpiryDate = centers.TradeLicenseExpiryDate;
            map.FaxNo = centers.FaxNo;
            map.PhoneNo = centers.PhoneNo;
            map.WebSite = centers.WebSite;
            map.Email = centers.Email;
            map.Latitude = centers.Latitude;
            map.Longitude = centers.Longitude;
            map.IsActive = true;
            map.IsDeleted = false;
            var result = _serviceFactory.CreateCenterService.InsertOrUpdateCenterTrans(map);
              

            return Ok(result);
        }

        /// <summary>
        /// Deletes the center trans.
        /// </summary>
        /// <param name="center">The center.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("DeleteCenterTrans")]
        [HttpPut]
        [ResponseType(typeof(AddUpdateCenterTransViewModel))]
        public IHttpActionResult DeleteCenterTrans(AddUpdateCenterTransViewModel center)
        {
            Guard.NotNull(center, "center parameter is null.,");
            Guard.NotDefault(center.Id, "center id is required.,");
            var map = AutoMapper.Mapper.Map<CenterTrans>(center);
            var result = _serviceFactory.CreateCenterService.DeleteCenterTrans(map);
            return Ok(result);
        }

        /// <summary>
        /// Gets all centers.
        /// </summary>
        /// <param name="langId">The language identifier.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("GetAllCentersByLangId")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Centers>))]
        public IHttpActionResult GetAllCenters(int langId)
        {
            Guard.NotDefault(langId, "Language Id is required.,");
            var result = _serviceFactory.CreateCenterService.GetAll(langId);
            return Ok(result);

        }
        /// <summary>
        /// Gets the center by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("GetCenterById")]
        [HttpGet]
        [ResponseType(typeof(Centers))]
        public IHttpActionResult GetCenterById(long id)
        {
            var result = _serviceFactory.CreateCenterService.GetCenterById(id);
            return Ok(result);
        }

        /// <summary>
        /// Gets the center by emirates identifier.
        /// </summary>
        /// <param name="emiratesId">The emirates identifier.</param>
        /// <param name="langId">The language identifier.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("GetCenterByEmiratesIdAndLangId")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Centers>))]
        public IHttpActionResult GetCenterByEmiratesId(int emiratesId, int langId)
        {
            Guard.NotDefault(emiratesId, "Emirates Id is null");
            Guard.NotDefault(emiratesId, "Lang Id is null");
            var result = _serviceFactory.CreateCenterService.GetAllCentersByEmiratesId(emiratesId, langId);
            return Ok(result);
        }
    }
}
