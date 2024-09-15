using Microsoft.Extensions.Options;
using MongoDB.Driver;
using UserManagement.Models;
using UserManagement.Settings;

namespace UserManagement.Persistence.DBContext
{
    public class UsersDBContext
    {
        private readonly IMongoDatabase _database;
        public UsersDBContext(IOptions<DBSettings> mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.Value.ConnectionString);
            _database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);
        }
        public IMongoCollection<Users> Users => _database.GetCollection<Users>("users");
    }
}
