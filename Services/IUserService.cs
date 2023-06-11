using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IUserService
    {
        List<Usuario> GetUsers();
        Usuario GetUserById(int id);
        Usuario PostUser(Usuario user);
        List<Usuario> PutUser(int id, Usuario usuario);
        void DeleteUser(int id);
    }
}
