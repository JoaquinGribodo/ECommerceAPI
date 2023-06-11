using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService _userService;

        private UserController(UserService userService)
        {
            _userService = userService;
        }
        [HttpGet("GetUsers")]
        public ActionResult<List<Usuario>> GetUsers()
        {
            return Ok(_userService.GetUsers());
        }

        [HttpGet("GetUsers/{id}")]
        public ActionResult<Usuario> GetUserById(int id)
        {
            return Ok(_userService.GetUserById(id));
        }

        [HttpPost("PostUser")]
        public ActionResult<Usuario> PostUser([FromBody] Usuario user)
        {
            return Ok(_userService.PostUser(user));
        }

        [HttpPut("PutUser/{id}")]
        public ActionResult<Usuario> PutUser(int id, [FromBody] Usuario user)
        {
            return Ok(_userService.PutUser(id, user));
        }

        [HttpDelete("DeleteUser/{id}")]
        public ActionResult<Usuario> DeleteUser(int id)
        {
            return Ok(_userService.DeleteUser(id));
        }
    }
}
