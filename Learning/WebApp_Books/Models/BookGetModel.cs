using BooksDatastore.Core;
using System;


namespace WebApp_Books.Models
{
    public class BookGetModel
    {
        public int Id;

        public string Name;

        public string Author;

        public DateTimeOffset YearProduction;

        public int Pages;

        public BookGetModel(Book book)
        {
            Id = book.Id;
            Name = book.Name;
            Author = book.Author;
            YearProduction = book.YearProduction;
            Pages = book.Pages;
        }
    }
}
