using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BooksDatastore.Core;
using BooksDatastore.InMemory;
using Microsoft.AspNetCore.Mvc;
using WebApp_Books.Models;


namespace WebApp_Books.Controllers
{
    public class BooksController : Controller
    {
        [HttpGet("/api/books")]
        public IActionResult GetBooks()
        {
            IBooksStorage dataStore = InMemoryDataStore.GetInstance();

            List<BookGetModel> result = dataStore
                                    .GetBook()
                                    .Select(x => new BookGetModel(x))
                                    .ToList();

            return Ok(result);
        }

        [HttpGet("/api/books/{id}")]
        public IActionResult GetBooks(int id)
        {
            IBooksStorage dataStore = InMemoryDataStore.GetInstance();

            var temp = dataStore.GetBook(id);

            if (temp != null)
            {
                return Ok(new BookGetModel(temp));
            }

            return NotFound();
        }

        [HttpPost("/api/books/")]
        public IActionResult AddBooks([FromBody]BookCreateModel newBook)
        {
            IBooksStorage dataStore = InMemoryDataStore.GetInstance();

            if (newBook == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            int index = dataStore.AddBook(newBook.Name,
                                        newBook.Author,
                                        newBook.YearProduction,
                                        newBook.Pages);

            return Created($"/api/books/{index}",
                            new BookGetModel(dataStore.GetBook(index)));
        }

        [HttpPut("/api/books/{id}")]
        public IActionResult UpdateBooks(int id, [FromBody]BookCreateModel updatedBook)
        {
            IBooksStorage dataStore = InMemoryDataStore.GetInstance();

            bool result = dataStore.UpdateBook(id,
                                            updatedBook.Name,
                                            updatedBook.Author,
                                            updatedBook.YearProduction,
                                            updatedBook.Pages);

            if (result)
                return Ok(new BookGetModel(dataStore.GetBook(id)));

            return NotFound();
        }

        [HttpDelete("/api/books/{id}")]
        public IActionResult DeleteBooks(int id)
        {
            IBooksStorage dataStore = InMemoryDataStore.GetInstance();

            var result = dataStore.DeleteBook(id);

            if (result)
                return Ok();

            return NotFound();
        }
    }
}

