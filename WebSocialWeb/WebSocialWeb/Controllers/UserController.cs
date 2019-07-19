using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebSocialWeb.Services;

namespace WebSocialWeb.Controllers
{
    [Route("api/users")]
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

        public IHttpActionResult GetAll()
        {
            return Ok(_userService.GetAll());
        }
    }
}
