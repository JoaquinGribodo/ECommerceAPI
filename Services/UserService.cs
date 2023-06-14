using Data.Models;
using Data.Repositories;

namespace Services
{
    public class UserService : IUserService
    {
        private UserRepository _userRepository { get; set; }

        public UserService(UserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        private UserService() { }
        
        public Usuario GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public List<Usuario> GetUsers() 
        {
            return _userRepository.GetUsers();
        }

        public List<Usuario> PutUser(int id, Usuario usuario)
        {
            return _userRepository.PutUser(id, usuario);
        }

        public Usuario PostUser(Usuario usuario)
        {
            return _userRepository.PostUser(usuario);
        }

        public void DeleteUser(int id)
        {
             _userRepository.DeleteUser(id);
        }

    }
}
