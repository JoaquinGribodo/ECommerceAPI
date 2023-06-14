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
        public List<Usuario> GetUsers()
        {
            return _dbContext.Usuario.ToList();
        }

        public Usuario GetUserById(int id)
        {
            Usuario usuario = Users.Where(x => x.IdProducto == id).FirstOrDefault();

            return usuario;
        }
        public Usuario PostUser(UserViewModel usuario)
        {
            Usuario usuario1 = new Usuario()
            {
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Correo = usuario.Correo,
                IdRol = usuario.IdRol,

            };
            _dbContext.Usuario.Add(usuario1);
            _dbContext.SaveChanges();

            return usuario1;
        }
        public List<Usuario> PutUser(int id, Usuario usuario)
        {
            var usuarioAModificar = Users.Where(x => x.IdProducto == id).First();
            usuarioAModificar.Id = usuario.Id;
            usuarioAModificar.Nombre = usuario.Nombre;
            usuarioAModificar.Apellido = usuario.Apellido;
            usuarioAModificar.IdRol = usuario.IdRol;

            return Users;
        }
        public void DeleteUser(int id)
        {
            Usuario usuario = Users.Where(w => w.Id == id).First();
            Users.Remove(usuario);
        }
    }
}
