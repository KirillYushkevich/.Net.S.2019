using System;
using System.Collections.Generic;
using ELibrary.Data.Models;

namespace ELibrary.Data.Presenters
{
    public class BookListService
    {
        public List<Book> BookList = new List<Book>();

        private List<string> paths = new List<string>();

        private const string StoragePath = "BookListService.bin";

        /// <summary>Load Books From List of paths to files</summary>
        public void LoadBooks()
        {
            foreach (string path in paths)
            {
                BookList.AddRange(StorageService.LoadFromFile(StoragePath));
            }
        }

        /// <summary>Save Books to file</summary>
        /// <param name="path">path to file</param>
        public void SaveToFile(string path = StoragePath)
        {
            StorageService.SaveToFile(path, BookList);
        }

        /// <summary>Add book to list/summary>
        /// <param name="newBook">Book to add</param>
        public void AddBook(Book newBook)
        {
            if (BookList.Contains(newBook))
            {
                throw new Exception("This book already in storage");
            }

            BookList.Add(newBook);
        }

        /// <summary>Remove books from list</summary>
        /// <param name="newBook">Book to remove</param>
        public void RemoveBook(Book newBook)
        {
            if (!BookList.Contains(newBook))
            {
                throw new Exception("There is no such book in storage");
            }

            BookList.Remove(newBook);
        }

        /// <summary>Serch book by tag</summary>
        /// <param name="tagName">Name of tag</param>
        /// <param name="tagValue">Tag</param>
        /// <returns>Book.ToString()</returns>
        public string FindBookByTag(string tagName, string tagValue)
        {
            foreach (Book b in BookList)
            {
                if (b.Equals(tagName, tagValue))
                {
                    return b.ToString();
                }
            }

            throw new Exception("There is no such book");
        }

        /// <summary>Sorts books by tag</summary>
        /// <param name="tagName">Name of tag</param>
        public void SortByTag(string tagName)
        {
            BookList.Sort(new BookComparer(tagName).Compare);
        }
    }
}
