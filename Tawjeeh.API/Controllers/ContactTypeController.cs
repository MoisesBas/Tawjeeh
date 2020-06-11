using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
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
    [RoutePrefix("contacttype")]
    public class ContactTypeController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactTypeController"/> class.
        /// </summary>
        /// <param name="_serviceFactory">The service factory.</param>
        /// <param name="_sms">The SMS.</param>
        public ContactTypeController(IServiceFactory _serviceFactory, ISms _sms) : base(_serviceFactory,_sms)
        {

        }

        /// <summary>
        /// Gets the type of all contac.
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("GetAllContactType")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<ContactType>))]
        public IHttpActionResult GetAllContacType()
        {
            var result = _serviceFactory.CreateContactTypeService.GetAllContactType();             
            return Ok(result);
        }

        /// <summary>
        /// Creates the specified conttype.
        /// </summary>
        /// <param name="conttype">The conttype.</param>
        /// <returns></returns>
        /// <exception cref="HttpResponseException"></exception>
        [AllowAnonymous]
        [Route("AddContactType")]
        [HttpPut]
        [ResponseType(typeof(AddUpdateContactType))]
        public IHttpActionResult Create(AddUpdateContactType conttype)
        {

            Guard.NotNullOrEmpty(conttype.Name, "Contact Type Name is required.");
            var map = AutoMapper.Mapper.Map<ContactType>(conttype);
            var isexist = _serviceFactory.CreateContactTypeService.GeTContactTypeByName(map.Name);

            if (isexist != null)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Conflict, "Contact Type is exists.,"));


            var result = _serviceFactory.CreateContactTypeService
                                        .InsertOrUpdateContactTypeService(map);
            return Ok(result);
        }


        /// <summary>
        /// Deletes the specified conttype.
        /// </summary>
        /// <param name="conttype">The conttype.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("DeleteContactType")]
        [HttpPut]
        [ResponseType(typeof(AddUpdateContactType))]
        public IHttpActionResult Delete(AddUpdateContactType conttype)
        {
            Guard.NotNull(conttype, nameof(conttype));
            var map = AutoMapper.Mapper.Map<ContactType>(conttype);
            var result = _serviceFactory.CreateContactTypeService.Delete(map);
            return Ok(result);
        }        
    }
}
