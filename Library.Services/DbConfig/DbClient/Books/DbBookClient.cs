using Library.Services.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.DbConfig.DbClient.Books
{
    public class DbBookClient : IDbBookClient
    {
        private readonly IMongoCollection<Book> _books;
        public DbBookClient(IOptions<BookStoreDbConfig> options)
        {
            var client = new MongoClient(options.Value.Connection_String);
            var database = client.GetDatabase(options.Value.Database_Name);
            _books = database.GetCollection<Book>(options.Value.Books_Collection_Name);
        }
        public IMongoCollection<Book> GetBooksCollection() => _books;
    }
}
