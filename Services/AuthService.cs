using Data.Models;
using Data.Models.Helper;
using Data.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly ECommerceDBContext _dbContext;
        private readonly AppSettings _appSettings;

        public AuthService(ECommerceDBContext context, IOptions<AppSettings> appSettings)
        {
            _dbContext = context;
            _appSettings = appSettings.Value;
        }

        public string CrearUsuario(UserViewModel User)
        {
            if (string.IsNullOrEmpty(User.Correo))
            {
                return "Ingrese un usuario";
            }

            Usuario? user = _dbContext.Usuario.FirstOrDefault(x => x.Correo == User.Correo);

            if (user != null)
            {
                return "Usuario existente";
            }

            _dbContext.Usuario.Add(new Usuario()
            {
                Nombre = User.Nombre,
                Apellido = User.Apellido,
                Correo = User.Correo,
                Contrasenia = User.Contrasenia.GetSHA256(),
                IdRol = User.IdRol,
            });
            _dbContext.SaveChanges();

            string response = GetToken(_dbContext.Usuario.OrderBy(x => x.Id).Last());

            return response;
        }

        public string Login(AuthViewModel User)
        {
            Usuario? user = _dbContext.Usuario.FirstOrDefault(x => x.Correo == User.Correo && x.Contrasenia == User.Contrasenia);

            if (user == null)
            {
                return string.Empty;
            }

            return GetToken(user);
        }

        private string GetToken(Usuario user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Email, user.Correo),
                        new Claim(ClaimTypes.Role, _dbContext.RolUsuario.First(x => x.Id == user.IdRol).Descripcion)
                    }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }
    }
}
