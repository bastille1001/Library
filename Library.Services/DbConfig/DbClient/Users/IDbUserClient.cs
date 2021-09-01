using Library.Services.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.DbConfig.DbClient.Users
{
    public interface IDbUserClient
    {
        IMongoCollection<User> GetUsersCollection();
    }
}
