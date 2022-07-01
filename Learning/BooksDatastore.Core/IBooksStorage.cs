using System;
using System.Collections.Generic;
using System.Text;

namespace BooksDatastore.Core
{
    public interface IBooksStorage
    {
        Book GetBook(int id);

        List<Book> GetBook();

        int AddBook(string name, string author, DateTime yearProduction, int pages);

        bool UpdateBook(int id, string name, string author, DateTime yearProduction, int pages);

        bool DeleteBook(int id);
    }
}
