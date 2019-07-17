using Dtos;
using WebSocialWeb.Repositories;

namespace WebSocialWeb.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        //public UserDto Get(int id)
        //{
        //    var user = _userRepository.Get(id);

        //} 
    }
}