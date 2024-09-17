using UserManagement.Models;

namespace UserManagement.Services.Interface
{
    public interface IUserservice
    {
        Task CreateUserAsync(Users user);
        Task<Users> GetUserByIdAsync(string id);
        Task<List<Users>> GetAllUsersAsync();
        Task UpdateUserAsync(string id, Users user);
        Task DeleteUserAsync(string id);
    }
}
