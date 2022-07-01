using BooksDatastore.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp_Books.Models
{
    public class BookCreateModel
    {

        [Required]
        public string Name;

        public string Author;

        public DateTime YearProduction;

        public int Pages;

        public Book ConvertToBook(int id)
        {
            return  new Book
            {
                Id = id,
                Name = Name,
                Author = Author,
                YearProduction = YearProduction,
                Pages = Pages
            };
        }
    }
}
