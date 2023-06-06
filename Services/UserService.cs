using Data.Entities;
using Data.Repositories;

namespace Services
{
    public class UserService
    {
        UserRepository repository = new UserRepository();
        public User GetUserById(int id)
        {
            return repository.GetUserById(id);
        }
        public User GetUsers()
        {
            UserRepository repository = new UserRepository();
            return repository.GetUsers();

        }
        public User PostUser()
        {
            UserRepository repository = new UserRepository();
            return repository.PostUser();

        }
        public User PutUser(int id)
        {
            UserRepository repository = new UserRepository();
            return repository.PutUser(id);

        }
        public User DeleteUser(int id)
        {
            UserRepository repository = new UserRepository();
            return repository.DeleteUser(id);

        }
    }
}
}
}

}
}