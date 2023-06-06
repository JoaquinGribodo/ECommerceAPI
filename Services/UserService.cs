using Data.Entities;
using Data.Repositories;

namespace Services
{
    public class UserService
    {
        UserRepository _userRepository = new UserRepository();
        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }
        public User GetUsers()
        {
            return _userRepository.GetUsers();

        }
        public User PostUser()
        {
            return _userRepository.PostUser();

        }
        public User PutUser(int id)
        {
            return _userRepository.PutUser(id);

        }
        public User DeleteUser(int id)
        {
            return _userRepository.DeleteUser(id);

        }
    }
}
}
}

}
}