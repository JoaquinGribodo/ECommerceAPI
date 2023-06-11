using Data.Entities;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UserRepository
    {
        public List<Usuario> GetUsers()
        {
            return Users;
        }

        public Usuario GetUserById(int id)
        {
            Usuario usuario = Users.Where(x => x.IdProducto == id).FirstOrDefault();

            return usuario;
        }
        public Usuario PostUser(Usuario usuario)
        {
            Users.Add(usuario);

            return usuario;
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
