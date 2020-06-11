using BusinessDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Hubs;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/happface")]
    public class HappyFaceController : HappyFaceWithHubController<HappyFaceHub>
    {
        private BusinessEntities.UserService _userService;  
        public HappyFaceController()
        {
            _userService = new BusinessEntities.UserService();           
        }
        [AllowAnonymous]
        [Route("SetHappyFace")]
        [HttpPost]
        public IHttpActionResult SetHappyFace(HappyFaceDTO happyFace)
        {
            if (happyFace == null) throw new ArgumentNullException(nameof(happyFace));
            var result = _userService.SetHappyFace(happyFace);
            if(result != null)
            {
                var subscribed = Hub.Clients.Group(result.InterviewerID.ToString());
                subscribed.updateItem(happyFace);
            }
            return Ok(result);
        }
    }
}
