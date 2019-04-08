using System;
using System.Collections.Generic;
using ELibrary.Data.Models;

namespace ELibrary.Data.Presenters
{
    public class BookListService
    {      
        public List<Book> BookList = new List<Book>();

        private const string StoragePath = "BookListService.bin";

        public BookListService()
        {
            BookList = StorageService.LoadFromFile(StoragePath);
        }

        ~BookListService()
        {
            StorageService.SaveToFile(StoragePath, BookList);
        }

        public void AddBook(Book newBook)
        {
            if (BookList.Contains(newBook))
            {
                throw new Exception("This book already in storage");
            }

            BookList.Add(newBook);
        }

        public void RemoveBook(Book newBook)
        {
            if (!BookList.Contains(newBook))
            {
                throw new Exception("There is no such book in storage");
            }

            BookList.Remove(newBook);
        }

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

        public void SortByTag(string tagName)
        {
            BookList.Sort(new BookComparer(tagName).Compare);
        }
    }
}
