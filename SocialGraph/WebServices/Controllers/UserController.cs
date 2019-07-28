using System.Web.Http;
using Data.Services;

namespace WebServices.Controllers
{
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        private readonly UserService _userService;
        
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(_userService.Get(id));
        }

        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(_userService.GetAll());
        }


    }
}
