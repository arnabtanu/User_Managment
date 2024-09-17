using MongoDB.Driver;
using UserManagement.Models;
using UserManagement.Persistence.DBContext;
using UserManagement.Repository.Interface;

namespace UserManagement.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UsersDBContext _usersDBContext;
        public UserRepository(UsersDBContext usersDBContext) 
        { 
            _usersDBContext = usersDBContext;
        }

        public async Task DeleteUserAsync(string id)
        {
            var filter= Builders<Users>.Filter.Eq(u=>u.Id,id);
            await _usersDBContext.Users.DeleteOneAsync(filter);
        }

        public async Task<List<Users>> GetAllUsersAsync()
        {
            return await _usersDBContext.Users.Find<Users>(u => true).ToListAsync();
        }

        public async Task<Users> GetUserByIdAsync(string id)
        {
            var cursor = await _usersDBContext.Users.FindAsync<Users>(u => u.Id == id);
            return await cursor.FirstOrDefaultAsync();
        }

        public async Task InsertUserAsync(Users user)
        {
            await _usersDBContext.Users.InsertOneAsync(user);
        }

        public async Task UpdateUserAsync(string id, Users user)
        {
            var filter= Builders<Users>.Filter.Eq(u=>u.Id, id);
            var update = Builders<Users>.Update.
                Set(u => u.Username, user.Username).
                Set(u => u.Email, user.Email).
                Set(u => u.PasswordHash, user.PasswordHash).
                Set(u => u.Role, user.Role).
                Set(u => u.UpdatedAt, DateTime.UtcNow);
            await _usersDBContext.Users.UpdateOneAsync(filter, update);
        }
    }
}
