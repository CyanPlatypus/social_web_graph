using System.Web.Http;
using System.Web.Mvc;
using WebSocialWeb.Services;

namespace WebSocialWeb.Controllers
{
    [System.Web.Mvc.Route("api/users")]
    public class UserController : ApiController
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [System.Web.Mvc.Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(_userService.Get(id));
        }

        public IHttpActionResult GetAll()
        {
            return Ok(_userService.GetAll());
        }
    }
}