using System;
using System.Collections.Generic;
using ELibrary.Data.Models;
using HomeworkDay11.BooksLoger;

namespace ELibrary.Data.Presenters
{
    public class BookListService
    {
        private List<Book> BookList = new List<Book>();

        private Nloger _logger = new Nloger();

        private List<string> paths = new List<string>();

        private const string StoragePath = "BookListService.bin";

        /// <summary>Load Books From List of paths to files</summary>
        public void LoadBooks()
        {
            _logger.Debug("Load books from storage" + DateTime.Now);
            foreach (string path in paths)
            {
                
                BookList.AddRange(StorageService.LoadFromFile(StoragePath));
            }
        }

        /// <summary>Save Books to file</summary>
        /// <param name="path">path to file</param>
        public void SaveToFile(string path = StoragePath)
        {
            _logger.Debug("Save books to storage" + DateTime.Now);
            StorageService.SaveToFile(path, BookList);
        }

        /// <summary>Add book to list/summary>
        /// <param name="newBook">Book to add</param>
        public void AddBook(Book newBook)
        {
            if (BookList.Contains(newBook))
            {
                _logger.Warn("Adding already existing book" + DateTime.Now);
                throw new Exception("This book already in storage");
            }
            _logger.Debug("Added book" + DateTime.Now);
            BookList.Add(newBook);
        }

        /// <summary>Remove books from list</summary>
        /// <param name="newBook">Book to remove</param>
        public void RemoveBook(Book newBook)
        {
            if (!BookList.Contains(newBook))
            {
                _logger.Warn("Deleting non existing book" + DateTime.Now);
                throw new Exception("There is no such book in storage");
            }
            _logger.Debug("Deleted book" + DateTime.Now);
            BookList.Remove(newBook);
        }

        /// <summary>Serch book by tag</summary>
        /// <param name="tagName">Name of tag</param>
        /// <param name="tagValue">Tag</param>
        /// <returns>Book.ToString()</returns>
        public string FindBookByTag(string tagName, string tagValue)
        {
            _logger.Debug("Searching for book" + DateTime.Now);
            foreach (Book b in BookList)
            {
                if (b.Equals(tagName, tagValue))
                {
                    return b.ToString();
                }
            }

            return "there is no such book";
        }

        /// <summary>Sorts books by tag</summary>
        /// <param name="tagName">Name of tag</param>
        public void SortByTag(string tagName)
        {
            _logger.Debug("Sorting books" + DateTime.Now);
            BookList.Sort(new BookComparer(tagName).Compare);
        }
    }
}
