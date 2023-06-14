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
            var response = _userService.GetUsers();
            if(response.Count == 0)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpGet("GetUsers/{id}")]
        public ActionResult<Usuario> GetUserById(int id)
        {
            var response = _userService.GetUserById(id);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpPost("PostUser")]
        public ActionResult<Usuario> PostUser([FromBody] Usuario user)
        {
            var response = _userService.PostUser(user);
            if (response == null)
            {
                return BadRequest();  
            }
            string baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            string apiAndEndPointUrl = $"api/User/GetUsers";
            string locationUrl = $"{baseUrl}/{apiAndEndPointUrl} / {response.Id}";
            return Created(locationUrl, response);
        }

        [HttpPut("PutUser/{id}")]
        public ActionResult<Usuario> PutUser(int id, [FromBody] Usuario user)
        {
            var response = _userService.PutUser(id, user);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpDelete("DeleteUser/{id}")]
        public ActionResult<Usuario> DeleteUser(int id)
        {
            var response = _userService.DeleteUser(id);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
    }
}
