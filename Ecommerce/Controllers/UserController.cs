using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        ////establecer un endpoint, devuelve un JSON
        
        private readonly UserService _userService = new UserService();
        [HttpGet("GetUsers")]
        public ActionResult<List<User>> GetUsers()
        {
            var response = _userService.GetUsers();
            return Ok(response);
        }

        [HttpGet("GetUsers/{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            var response = _userService.GetUserById(id);
            return Ok(response);
        }

        [HttpPost("PostUser")]
        public ActionResult<User> PostUser([FromBody] User user)
        {
            var response = _userService.PostUser(user);
            return Ok(response);
        }

        [HttpPut("PutUser/{id}")]
        public ActionResult<User> PutUser(int id, [FromBody] User user)
        {
            var response = _userService.PutUser(id, user);
            return Ok(response);
        }

        [HttpDelete("DeleteUser/{id}")]
        public ActionResult<User> DeleteUser(int id)
        {
            var response = _userService.DeleteUser(id);
            return Ok(response);
        }
    }
}
