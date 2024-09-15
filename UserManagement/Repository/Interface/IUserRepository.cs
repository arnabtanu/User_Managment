using UserManagement.Models;

namespace UserManagement.Repository.Interface
{
    public interface IUserRepository
    {
        Task InsertUserAsync(Users user);
        Task<Users> GetUserByIdAsync(string id);
        Task<List<Users>> GetAllUsersAsync();
        Task UpdateUserAsync(string id, Users user);
        Task DeleteUserAsync(string id);
    }
}
