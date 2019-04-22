using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Data.Models
{
    public sealed class Book : IEquatable<Book>
    {
        public readonly string Author;
        public readonly string ISBN;
        public readonly string Title;
        public readonly string Publisher;
        public readonly int PublishYear;
        public readonly int PageAmount;

        public Book(string isbn, string author, string title, string publisher, int publishYear, int pageAmount, int price)
        {
            ISBN = isbn;
            Author = author;
            Title = title;
            Publisher = publisher;
            PublishYear = publishYear;
            PageAmount = pageAmount;
            Price = price;
        }

        public int Price { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("ISBN:" + ISBN + "\n");
            sb.Append("Author:" + Author + "\n");
            sb.Append("Title:" + Title + "\n");
            sb.Append("Publisher:" + Publisher + "\n");
            sb.Append("Publish Year:" + PublishYear + "\n");
            sb.Append("Pages:" + PageAmount + "\n");
            sb.Append("Current Price" + Price + "\n");
            return sb.ToString();
        }

        public override int GetHashCode()
        {
            return ((Price + PublishYear + PageAmount) / 357) * 18;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Book))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool Equals(Book other)
        {
            if (this.ISBN == other.ISBN)
            {
                return true;
            }

            return false;
        }

        public bool Equals(string tagName, string tagValue)
        {
            if (this.GetType().GetField(tagName).GetValue(this).ToString() == tagValue)
            {
                return true;
            }

            return false;
        }
    }
}
