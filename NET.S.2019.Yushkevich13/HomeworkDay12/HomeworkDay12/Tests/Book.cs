using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkDay12.Tests
{
    public sealed class Book : IComparable<Book>, IEquatable<Book>
    {
        public Book(string author, string title)
        {
            this.Author = author;
            this.Title = title;
        }

        public string Author { get; }

        public string Title { get; }

        public static bool operator ==(Book book1, Book book2) => EqualityComparer<Book>.Default.Equals(book1, book2);

        public static bool operator !=(Book book1, Book book2) => !(book1 == book2);

        public int CompareTo(Book other)
            => (this.Author, this.Title).CompareTo((other.Author, other.Title));

        public override bool Equals(object obj) => this.Equals(obj as Book);

        public bool Equals(Book other)
            => other != null && this.GetType() == other.GetType() &&
               this.Author == other.Author && this.Title == other.Title;

        public override int GetHashCode() => (this.Author, this.Title).GetHashCode();
    }
}