using Library.Services.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Library.Services.DbConfig.DbClient.Users
{
    public class DbUserClient : IDbUserClient
    {
        private readonly IMongoCollection<User> _users;
        public DbUserClient(IOptions<UserStoreDbConfig> options)
        {
            var client = new MongoClient(options.Value.Connection_String);
            var database = client.GetDatabase(options.Value.Database_Name);
            _users = database.GetCollection<User>(options.Value.Users_Collection_Name);
        }

        public IMongoCollection<User> GetUsersCollection() => _users;
    }
}
