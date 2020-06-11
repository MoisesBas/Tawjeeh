using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using Tawjeeh.Api.Models;
using Tawjeeh.Api.Plugins;
using Tawjeeh.EntityModel;
using Tawjeeh.EntityServices.Interface;
using Tawjeeh.Infrastructure;

namespace Tawjeeh.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Tawjeeh.Api.Controllers.BaseController" />
    [RoutePrefix("laws")]
    public class LawsController : BaseController    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LawsController"/> class.
        /// </summary>
        /// <param name="_serviceFactory">The service factory.</param>
        /// <param name="_sms">The SMS.</param>
        public LawsController(IServiceFactory _serviceFactory,ISms _sms) :
            base(_serviceFactory,_sms)
        {           

        }

        /// <summary>
        /// Gets all laws.
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("GetAllLaws")]
        [HttpGet]
        public IHttpActionResult GetAllLaws()
        {
            var result = _serviceFactory.CreateLawsService.GetAll();
            return Ok(result);
        }
        /// <summary>
        /// Deletes the specified laws.
        /// </summary>
        /// <param name="laws">The laws.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("DeleteLaws")]
        [HttpPut]
        [ResponseType(typeof(AddUpdateLawViewModel))]
        public IHttpActionResult Delete(AddUpdateLawViewModel laws)
        {
            Guard.NotNull(laws, "Law object is null.,");
            var map = AutoMapper.Mapper.Map<Law>(laws);
            map.UpdatedBy = 1;
            var result = _serviceFactory.CreateLawsService.DeleteLaw(map);
            return Ok(result);
        }

        /// <summary>
        /// Gets the laws by identifier and language identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="langId">The language identifier.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("GetLawsByIdAndLangId")]
        [HttpGet]
        [ResponseType(typeof(Law))]
        public IHttpActionResult GetLawsByIdAndLangId(Int64 id, int langId)
        {
            var result = _serviceFactory.CreateLawsService.GetLawByIdAndLangId(id, langId);
            return Ok(result);
        }

        /// <summary>
        /// Gets the laws by identifier.
        /// </summary>
        /// <param name="lawId">The law identifier.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("GetLawsById")]
        [HttpGet]
        [ResponseType(typeof(Law))]
        public IHttpActionResult GetLawsById(Int64 lawId)
        {
            var result = _serviceFactory.CreateLawsService.GetLawById(lawId);
            return Ok(result);
        }

        /// <summary>
        /// Creates the law trans.
        /// </summary>
        /// <param name="lawtrans">The lawtrans.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("AddUpdateLawTrans")]
        [HttpPut]
        [ResponseType(typeof(AddUpdateLawTranslationViewModel))]
        public IHttpActionResult CreateLawTrans(AddUpdateLawTranslationViewModel lawtrans)
        {
            Guard.NotNull(lawtrans, "Law Translation model is null.,");
            Guard.NotDefault(lawtrans.LangId, "Language Id is null.,");
            Guard.NotDefault(lawtrans.LawId, "Law Id is null.,");
            var map = AutoMapper.Mapper.Map<LawTrans>(lawtrans);
            var result = _serviceFactory.CreateLawsService.InsertOrUpdateLawTrans(map);
            return Ok(result);
        }
        /// <summary>
        /// Deletes the law trans.
        /// </summary>
        /// <param name="lawtrans">The lawtrans.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("DeleteLawTrans")]
        [HttpPut]
        [ResponseType(typeof(AddUpdateLawViewModel))]
        public IHttpActionResult DeleteLawTrans(AddUpdateLawViewModel lawtrans)
        {
            Guard.NotNull(lawtrans, "Law Translation model is null.,");
            var map = AutoMapper.Mapper.Map<LawTrans>(lawtrans);
            var result = _serviceFactory.CreateLawsService.DeleteLawTrans(map);
            return Ok(result);
        }
    }
}
