using Library.Services.DbConfig.DbClient;
using Library.Services.Models;
using Library.Services.Services.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Library.Services.Services.Implementations
{
    public class BookService : IBookServices
    {
        private readonly IMongoCollection<Book> _books;
        public BookService(IDbBookClient dbClient) =>
            _books = dbClient.GetBooksCollection();

        public Book AddBook(Book book)
        {
            _books.InsertOne(book);
            return book;
        }

        public void DeleteBook(string id)
        {
            _books.DeleteOne(x => x.Id == id);
        }

        public Book GetBook(string id) =>
            _books.Find(x => x.Id == id).FirstOrDefault();

        public List<Book> GetBooks() =>
            _books.Find(x => true).ToList();

        public Book UpdateBook(Book book)
        {
            GetBook(book.Id);
            _books.ReplaceOne(x => x.Id == book.Id, book);
            return book;
        }
    }
}
