using System.Collections.Generic;
using System.Threading.Tasks;
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
    [RoutePrefix("utility")]
    public class UtilityController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UtilityController"/> class.
        /// </summary>
        /// <param name="_serviceFactory">The service factory.</param>
        /// <param name="_sms">The SMS.</param>
        public UtilityController(IServiceFactory _serviceFactory, ISms _sms) :
            base(_serviceFactory,_sms)
        {
        }

        /// <summary>
        /// Gets all country.
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("GetAllCountry")]
        [HttpGet]
        [ResponseType(typeof(List<Country>))]
        public IHttpActionResult GetAllCountry()
        {
            var result = _serviceFactory.CreateUtilityService.GetAllCountry();
            return Ok(result);
        }
        /// <summary>
        /// Adds the update country.
        /// </summary>
        /// <param name="country">The country.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("AddUpdateCountry")]
        [HttpPut]
        [ResponseType(typeof(Country))]
        public IHttpActionResult AddUpdateCountry(Country country)
        {
            Guard.NotNull(country, nameof(country));
            var result = _serviceFactory.CreateUtilityService.InsetOrUpdateCountry(country);
            return Ok(result);
        }
        /// <summary>
        /// Gets the type of all initiative.
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("GetAllInitiativeType")]
        [HttpGet]
        [ResponseType(typeof(List<InitiativeType>))]
        public IHttpActionResult GetAllInitiativeType()
        {
            var result = _serviceFactory.CreateUtilityService.GetInitiativeTypeAll();
            return Ok(result);
        }
        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="Number">The number.</param>
        /// <param name="Message">The message.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("ChangePassword")]
        [HttpGet]
        public async Task<IHttpActionResult> ChangePassword(string Number, string Message)
        {
            var result = await _sms.Send(Number, Message);
            return Ok(result);
        }

        /// <summary>
        /// Gets the multimedia type all.
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("GetMultimediaTypeAll")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<MultimediaType>))]
        public IHttpActionResult GetMultimediaTypeAll()
        {
            var result = _serviceFactory.CreateUtilityService.GetAllMultimediaType();
            return Ok(result);
        }
    }
}
