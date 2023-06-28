using Azure;
using Data.Models;
using Data.Models.DTO;
using Data.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger) 
        {
            _userService = userService;
            _logger = logger;
        }
        [HttpGet("GetUsers")]
        public ActionResult<List<UserDTO>> GetUsers()
        {
            try
            {
                var response = _userService.GetUsers();
                if (response.Count == 0)
                {
                    return NotFound("No pudo encontrarse la lista de usuarios.");
                }
                return Ok(response);
            }
            catch (Exception exe)
            {
                _logger.LogError($"Ocurrió un error en el método GetUsers: {exe.Message}");
                return BadRequest($"{exe.Message}");
            }
           
        }

        [HttpGet("GetUsers/{id}")]
        public ActionResult<UserDTO> GetUserById(int id)
        {
            //string? rol = User.Claims.FirstOrDefault(c => c.Properties.ContainsKey("role"))?.Value;

            //if(rol == "admin")
            //{
            //    return Ok();
            //}
            //else
            //{
            //    return Unauthorized();
            //}


            try
            {
                var response = _userService.GetUserById(id);
                if (response == null)
                {
                    return NotFound("No pudo encontrarse el usuario correspondiente a ese Id.");
                }
                return Ok(response);

            }
            catch(Exception exe)
            {
                _logger.LogError($"Ocurrió un error en el método GetUsers/id: {exe.Message}");
                return BadRequest($"{exe.Message}");
            }
            
        }

        [HttpPost("PostUser")]
        public ActionResult<UserDTO> PostUser([FromBody] UserViewModel usuario)
        {
            try
            {
                var response = _userService.PostUser(usuario);
                if (response == null)
                {
                    return NotFound("No existe ningún usuario");
                }
                string baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
                string apiAndEndPointUrl = $"api/User/GetUsers";
                string locationUrl = $"{baseUrl}/{apiAndEndPointUrl}/{response.Id}";
                return Created(locationUrl, response);
            }
            catch(Exception exe)
            {
                _logger.LogError($"Ocurrió un error en el método PostUser: {exe.Message}");
                return BadRequest($"{exe.Message}");
            }
            
        }

        [HttpPut("PutUser")]
        public ActionResult PutUser([FromBody] UserViewModel usuario)
        {
            try
            {
                var response = _userService.PutUser(usuario);
                string baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
                string apiAndEndPointUrl = $"api/User/GetUsers";
                string locationUrl = $"{baseUrl}/{apiAndEndPointUrl}/{response.Id}";
                return Created(locationUrl, response);
            }
            catch (Exception exe)
            {
                _logger.LogError($"Ocurrió un error en el método PutUser: {exe.Message}");
                return BadRequest($"{exe.Message}");
            }
            
        }

        [HttpDelete("DeleteUser/{id}")]
        public ActionResult<UserDTO> DeleteUser(int id)
        {
            try
            {
                _userService.DeleteUser(id);
                return Ok();
            }
            catch (Exception exe)
            {
                _logger.LogError($"Ocurrió un error en el método DeleteUser: {exe.Message}");
                return BadRequest($"{exe.Message}");
            }
            
        }
    }
}
