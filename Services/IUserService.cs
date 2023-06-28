using Data.Models;
using Data.Models.DTO;
using Data.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IUserService
    {
        List<UserDTO> GetUsers();
        UserDTO GetUserById(int id);
        UserDTO PostUser(UserViewModel usuario);
        UserDTO PutUser(UserViewModel usuario);
        void DeleteUser(int id);
    }
}
