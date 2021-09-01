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
        List<Book> GetBooks();
        Book GetBook(string id);
        Book AddBook(Book book);
    }
}
