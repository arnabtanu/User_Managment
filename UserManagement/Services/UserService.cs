using UserManagement.Models;
using UserManagement.Repository.Interface;
using UserManagement.Services.Interface;

namespace UserManagement.Services
{
    public class UserService : IUserservice
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }
        public async Task CreateUserAsync(Users user)
        {
            await _userRepository.InsertUserAsync(user);
        }

        public async Task DeleteUserAsync(string id)
        {
            await _userRepository.DeleteUserAsync(id);
        }

        public async Task<List<Users>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<Users> GetUserByIdAsync(string id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task UpdateUserAsync(string id, Users user)
        {
            await _userRepository.UpdateUserAsync(id, user);
        }
    }
}
