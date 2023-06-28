using Data.Models.DTO;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //Es un post porque creamos una sesiòn.
    public class AuthenticationController : ControllerBase
    {

        //Inyección de dependencias
        private readonly UserService _userService;
        private readonly ConfigurationManager _config;

        public AuthenticationController(UserService userService, ConfigurationManager configurationManager)
        {
            _userService = userService;
            _config = configurationManager;
        }
        [HttpPost]
        public ActionResult Authenticate([FromBody] Credentials credentials)
        {
            //autenticar si el usuario es válido o no
            //Autorizacion: permisos. Autenticacion: otro tipo de permisos.

            //Paso 1: Validamos las credenciales
            var user = _userService.ValidateUser(credentials.Username, credentials.Password);
            if (user == null)
            {
                return Forbid();
            }
            //Paso 2: Crear el token. Está instalado NuGet JwtBearer
            var salt = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Authentication:Salt"])); //Traemos la SecretKey del Json. agregar antes: using Microsoft.IdentityModel.Tokens;

            var signingCredentials = new SigningCredentials(salt, SecurityAlgorithms.HmacSha256); //Algoritmo de hasheo

            //Los claims son datos en clave->valor que nos permite guardar data del usuario.
            var claimsForToken = new List<Claim>();
            //La Claim de sub es obligatoria, luego decidir cuántas crear.
            claimsForToken.Add(new Claim("sub", user.Id.ToString())); //"sub" es una key estándar que significa unique user identifier, es decir, si mandamos el id del usuario por convención lo hacemos con la key "sub".
            claimsForToken.Add(new Claim("given_name", user.Name)); //Lo mismo para given_name y family_name, son las convenciones para nombre y apellido. Ustedes pueden usar lo que quieran, pero si alguien que no conoce la app
            //claimsForToken.Add(new Claim("family_name", user.LastName)); //quiere usar la API por lo general lo que espera es que se estén usando estas keys.
            claimsForToken.Add(new Claim("role", user.Role ?? "User")); //Debería venir del usuario

            var jwtSecurityToken = new JwtSecurityToken( //agregar using System.IdentityModel.Tokens.Jwt; Acá es donde se crea el token con toda la data que le pasamos antes.
              _config["Authentication:Issuer"],
              _config["Authentication:Audience"],
              claimsForToken,
              DateTime.UtcNow,  //Fecha de expiracion del Token
              DateTime.UtcNow.AddHours(1),
              signingCredentials);

            string tokenToReturn = new JwtSecurityTokenHandler() //Pasamos el token a string
                .WriteToken(jwtSecurityToken);

            return Ok(tokenToReturn);
        }
    }

}
