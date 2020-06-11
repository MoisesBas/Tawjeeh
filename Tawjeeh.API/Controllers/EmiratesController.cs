using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Tawjeeh.EntityModel;
using Tawjeeh.EntityServices.Interface;
using Tawjeeh.Infrastructure;

namespace Tawjeeh.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Tawjeeh.Api.Controllers.BaseController" />
    [RoutePrefix("emirates")]
    public class EmiratesController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmiratesController"/> class.
        /// </summary>
        /// <param name="_serviceFactory">The service factory.</param>
        /// <param name="_sms">The SMS.</param>
        public EmiratesController(IServiceFactory _serviceFactory,ISms _sms)
          : base(_serviceFactory,_sms)
        {

        }
        /// <summary>
        /// Gets all emirates.
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("GetAllEmirates")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Emirates>))]
        public IHttpActionResult GetAllEmirates()
        {
            var result = _serviceFactory.CreateEmiratesService.GetAll();
            return Ok(result);
        }
        /// <summary>
        /// Deletes the specified emirates.
        /// </summary>
        /// <param name="emirates">The emirates.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("DeleteEmirates")]
        [HttpPut]
        [ResponseType(typeof(Emirates))]
        public IHttpActionResult Delete(Emirates emirates)
        {
            var result = _serviceFactory.CreateEmiratesService.DeleteEmirates(emirates);
            return Ok(result);
        }

        /// <summary>
        /// Updates the specified emirates.
        /// </summary>
        /// <param name="emirates">The emirates.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("AddUpdateEmirates")]
        [HttpPut]
        [ResponseType(typeof(Emirates))]
        public IHttpActionResult Update(Emirates emirates)
        {
            var result = _serviceFactory.CreateEmiratesService.InsertOrUpdateEmirates(emirates);
            return Ok(result);
        }
        /// <summary>
        /// Gets the emirates by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("GetEmiratesById")]
        [HttpGet]
        [ResponseType(typeof(Emirates))]
        public IHttpActionResult GetEmiratesById(long id)
        {
            var result = _serviceFactory.CreateEmiratesService.GetEmiratesById(id);
            return Ok(result);
        }
    }
}
