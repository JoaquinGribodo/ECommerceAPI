using Data.Models;
using Data.Models.DTO;
using Data.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UserRepository
    {
        private readonly ECommerceDBContext _dbContext;
        public UserRepository(ECommerceDBContext eCommerceDBContext)
        {
            _dbContext = eCommerceDBContext;
        }
        public List<UserDTO> GetUsers()
        {
            List<UserDTO> response = new List<UserDTO>();
            List<Usuario> users = _dbContext.Usuario.ToList();
            foreach (var user in users)
            {
                response.Add(new UserDTO()
                {
                    Id = user.Id,
                    Nombre = user.Nombre,
                    Apellido = user.Apellido,
                    Correo = user.Correo,
                    IdRol = user.IdRol,
                });
            }
            return response;
        }

        public UserDTO GetUserById(int id)
        {
            UserDTO response = new UserDTO();
            Usuario user = _dbContext.Usuario.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                response.Id = user.Id;
                response.Nombre = user.Nombre;
                response.Apellido = user.Apellido;
                response.Correo = user.Correo;
                response.IdRol = user.IdRol;
            }
            return response;
        }
        public UserDTO PostUser(UserViewModel usuario)
        {                                                       
            _dbContext.Usuario.Add(new Usuario()
            {
                Apellido = usuario.Apellido,
                Nombre = usuario.Nombre,
                Correo = usuario.Correo,
                IdRol = usuario.IdRol,

            });
            _dbContext.SaveChanges();

            var addedUser = _dbContext.Usuario.OrderBy(x => x.Id).Last();
            UserDTO response = new UserDTO()
            {
                Id = addedUser.Id,
                Nombre = addedUser.Nombre,
                Apellido = addedUser.Apellido,
                Correo = addedUser.Correo,
                IdRol = addedUser.IdRol,
            };
            return response;
        }
        public void PutUser(int id, UserViewModel usuario)
        {
            UserDTO response = new UserDTO();
            var usuarioAModificar = _dbContext.Usuario.FirstOrDefault(x => x.Id == id);
            if (usuario != null)
            {
                usuarioAModificar.Apellido = usuario.Apellido;
                usuarioAModificar.Nombre = usuario.Nombre;
                usuarioAModificar.Correo = usuario.Correo;
                usuarioAModificar.IdRol = usuario.IdRol;

                _dbContext.SaveChanges();
            }
        }
        public void DeleteUser(int id)
        {
            Usuario usuario = _dbContext.Usuario.First(w => w.Id == id);
            if (usuario != null)
            {
                _dbContext.Usuario.Remove(usuario);
                _dbContext.SaveChanges();
            }
        }
    }
}
