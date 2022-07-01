using BooksDatastore.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BooksDatastore.InMemory
{
    public class InMemoryDataStore : IBooksStorage
    {
        //синглтон начало
        public static InMemoryDataStore inMemoryDataStore;

        private Dictionary<int, Book> _datastore;

        private InMemoryDataStore()
        {
            _datastore = new Dictionary<int, Book>
            {
                    {
                        1,
                        new Book
                        {
                            Id = 1,
                            Name = "Водители фрегатов",
                            Author = "Николай Чуковский",
                            Pages = 500,
                            YearProduction = DateTimeOffset.Now
                        }
                     },
                    {
                         2,
                        new Book
                        {
                            Id = 2,
                            Name = "Дети капитана Грант1",
                            Author = "Жуль Верн",
                            Pages = 400,
                            YearProduction = DateTimeOffset.Now
                        }
                    }
            };
        }

        public static InMemoryDataStore GetInstance()
        {
            if(inMemoryDataStore == null)
            {
                inMemoryDataStore = new InMemoryDataStore();

                return inMemoryDataStore;
            }

            return inMemoryDataStore;
        }
        //синглтон конец



        public int AddBook(string name, string author, DateTime yearProduction, int pages)
        {
            int newId = _datastore.Keys.Max() + 1;

            _datastore.Add(newId, new Book
            {
                Id = newId,
                Name = name,
                Author = author,
                YearProduction = yearProduction,
                Pages = pages
            });

            return newId;
        }

        public bool DeleteBook(int id)
        {
            if (_datastore.ContainsKey(id))
            {
                _datastore.Remove(id);

                return true;
            }

            return false;
        }

        public Book GetBook(int id)
        {
            if (_datastore.ContainsKey(id))
                return _datastore[id];

            return null;
        }

        public List<Book> GetBook()
        {
            return _datastore.Values.ToList();
        }

        public bool UpdateBook(int id, string name, string author, DateTime yearProduction, int pages)
        {
            if (_datastore.ContainsKey(id))
            {
                _datastore[id].Name = name;
                _datastore[id].Author = author;
                _datastore[id].YearProduction = yearProduction;
                _datastore[id].Pages = pages;

                return true;
            }

            return false;
        }
    }
}
