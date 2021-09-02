using Library.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Services.Interfaces
{
    public interface IBookServices
    {
        List<Book> GetByGenre(string genre);
        List<Book> GetBooks();
        Book GetBook(string id);
        Book AddBook(Book book);
        void DeleteBook(string id);
        Book UpdateBook(Book book);
    }
}
