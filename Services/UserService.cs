using Data.Models;
using Data.Models.DTO;
using Data.Models.ViewModel;
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

        public UserDTO GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public List<UserDTO> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        public UserDTO PutUser(UserViewModel usuario)
        {
            return _userRepository.PutUser(usuario);
        }

        public UserDTO PostUser(UserViewModel usuario)
        {
            return _userRepository.PostUser(usuario);
        }

        public void DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
        }

    }
}
