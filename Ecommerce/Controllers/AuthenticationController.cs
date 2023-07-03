using Data.Models.DTO;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Data.Models.ViewModel;
using Service.IServices;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService service, ILogger<AuthController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost("Login")]
        public ActionResult<string> Login([FromBody] AuthViewModel User)
        {
            string response = string.Empty;
            try
            {
                response = _service.Login(User);
                if (string.IsNullOrEmpty(response))
                    return NotFound("email/contraseña incorrecta");
            }
            catch (Exception ex)
            {
                _logger.LogError("Login", ex);
                return BadRequest($"{ex.Message}");
            }

            return Ok(response);
        }

        [HttpPost("CrearUsuario")]
        public ActionResult<string> CrearUsuario([FromBody] UserViewModel User)
        {
            string response = string.Empty;
            try
            {
                response = _service.CrearUsuario(User);
                if (response == "Ingrese un usuario" || response == "Usuario existente")
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                _logger.LogError("CrearUsuario", ex);
                return BadRequest($"{ex.Message}");
            }

            return Ok(response);
        }
    }

}
