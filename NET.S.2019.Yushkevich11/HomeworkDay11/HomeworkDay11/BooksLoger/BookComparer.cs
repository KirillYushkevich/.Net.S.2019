using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Data.Models
{
    public sealed class BookComparer : IComparer<Book>
    {      
        private SortBy _compareFild;

        public BookComparer(string compareField)
        {
            _compareFild = (SortBy)Enum.Parse(typeof(SortBy), compareField);
        }

        private enum SortBy
        {
            Title,
            Author,
            ISBN,
            Publisher,
            PublishYear,
            PageAmount,
            Price
        }

        public int Compare(Book x, Book y)
        {
            switch (_compareFild)
            {
                case SortBy.ISBN:
                    return x.ISBN.CompareTo(y.ISBN);
                case SortBy.Title:
                    return x.Title.CompareTo(y.Title);
                case SortBy.PageAmount:
                    return x.PageAmount.CompareTo(y.PageAmount);
                case SortBy.Price:
                    return x.Price.CompareTo(y.Price);
                case SortBy.Publisher:
                    return x.Publisher.CompareTo(y.Publisher);
                case SortBy.PublishYear:
                    return x.PublishYear.CompareTo(y.PublishYear);
                case SortBy.Author:
                    return x.Author.CompareTo(y.Author);
                default:
                    break;
            }

            return x.ISBN.CompareTo(y.ISBN);
        }
    }
}
