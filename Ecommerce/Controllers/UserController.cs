using Data.Models;
using Data.Models.DTO;
using Data.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        private UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("GetUsers")]
        public ActionResult<List<UserDTO>> GetUsers()
        {
            var response = _userService.GetUsers();
            if (response.Count == 0)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpGet("GetUsers/{id}")]
        public ActionResult<UserDTO> GetUserById(int id)
        {
            var response = _userService.GetUserById(id);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpPost("PostUser")]
        public ActionResult<UserDTO> PostUser([FromBody] UserViewModel usuario)
        {
            var response = _userService.PostUser(usuario);
            if (response == null)
            {
                return BadRequest(); 
            }
            string baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}"; 
            string apiAndEndPointUrl = $"api/Product/GetProducts";
            string locationUrl = $"{baseUrl}/{apiAndEndPointUrl} / {response.Id}";
            return Created(locationUrl, response); 
        }

        [HttpPut("PutUser/{id}")]
        public ActionResult PutUser(int id, [FromBody] UserViewModel usuario)
        {
            _userService.PutUser(id, usuario);
            return Ok();
        }

        [HttpDelete("DeleteUser/{id}")]
        public ActionResult<UserDTO> DeleteUser(int id)
        {
            _userService.DeleteUser(id);
            return Ok();
        }
    }
}
