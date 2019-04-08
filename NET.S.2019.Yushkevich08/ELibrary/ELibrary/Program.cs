using ELibrary.Data.Models;
using ELibrary.Data.Presenters;
using System;


namespace ELibrary
{
    class ConsoleApp
    {
        static void Main(string[] args)
        {
            Book b1 = new Book("1","Bell","lol","Lino",1975,612,254);
            Book b2 = new Book("2", "Bell", "lol", "Lino", 1974, 612, 254);
            Book b3 = new Book("3", "Bell", "lol", "Lino", 1973, 612, 254);
            Book b4 = new Book("4", "Bell", "lol", "Lino", 1972, 612, 254);
            Book b5 = new Book("5", "Bell", "lol", "Lino", 1971, 612, 254);

            BookListService service = new BookListService();
            service.AddBook(b1);
            service.AddBook(b2);
            service.AddBook(b3);
            service.AddBook(b4);
            service.AddBook(b5);

            
            foreach (Book ba in service.BookList)
            {
                Console.WriteLine(ba.ToString());
            }
            service.SortByTag("PublishYear");
            foreach (Book ba in service.BookList)
            {
                Console.WriteLine(ba.ToString());
            }

            service.RemoveBook(b2);
            foreach (Book ba in service.BookList)
            {
                Console.WriteLine(ba.ToString());
            }
            Console.WriteLine(service.FindBookByTag("PublishYear","1973"));
            Console.ReadKey();
        }
    }
}
