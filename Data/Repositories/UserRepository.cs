using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UserRepository
    {
        public static List<User> Users = new List<User>()
        {
            new User
            {
            Id = 1,
            Name = "belu",
            Email = "belu@belu",
            Password = "jgh"
            },
            new User
            {
            Id = 2,
            Name = "flor",
            Email = "flor@flor",
            Password = "aas"
            },
        };
        public User ? GetUserById(int id)
        {
            return Users.FirstOrDefault(x => x.Id == id);
        }
        public List<User?> GetUsers()
        {
            return Users;
        }
        public void PostUser(User user)
        {
            Users.Add(user);
        }
        public void PutUser(int id)
        {
            Users;
        }
        public void DeleteUser(int id)
        {
            Users.Remove(x => x.Id == id);
        }
    }
}
