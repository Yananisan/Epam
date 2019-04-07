using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2019.Ivanovskaya._08
{
    public class Book: IComparable, IEquatable<Book>
    {
        private string isbn;
        
        private string authorName;
        
        private string title;

        private string publisher;

        private int year;

        private int numberOfPages;

        private decimal price;

        public Book(string isbn, string authorName, string title, string publisher, int year, int numberOfPages, decimal price)
        {
            this.ISBN = isbn;
            this.AuthorName = authorName;
            this.Title = title;
            this.Publisher = publisher;
            this.Year = year;
            this.NumberOfPages = numberOfPages;
            this.Price = price;
        }

        public string ISBN
        {
            get
            {
                return isbn;
            }

            internal set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Invalid {nameof(value)}");
                }

                isbn = value;
            }
        }

        public string AuthorName
        {
            get
            {
                return authorName;
            }

            internal set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Invalid {nameof(value)}");
                }

                authorName = value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }

            internal set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Invalid {nameof(value)}");
                }

                title = value;
            }
        }

        public string Publisher
        {
            get
            {
                return publisher;
            }

            internal set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Invalid {nameof(value)}");
                }

                publisher = value;
            }
        }

        public int Year
        {
            get
            {
                return year;
            }

            internal set
            {
                if (value < 0 || value > DateTime.Today.Year)
                {
                    throw new ArgumentException($"Invalid {nameof(value)}");
                }

                year = value;
            }
        }

        public int NumberOfPages
        {
            get
            {
                return numberOfPages;
            }

            internal set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Invalid {nameof(value)}");
                }

                numberOfPages = value;
            }
        }

        public decimal Price
        {
            get => price;
            internal set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Invalid {nameof(value)}");
                }

                price = value;
            }
        }

        public override string ToString()
        {
            return $"ISBN: {ISBN}, AuthorName: {AuthorName}, Title: {Title}, Publisher: {Publisher}, Year: {Year}, Number of pages: {NumberOfPages}, Price: {Price}";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (obj.GetType() == GetType())
            {
                Book book = obj as Book;
                return this.Equals(book);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return ISBN.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return 1;
            }

            return obj.GetType() != GetType() ? 1 : CompareTo((Book)obj);
        }

        public bool Equals(Book other)
        {
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (ReferenceEquals(null, other))
            {
                return false;
            }

            return other.ISBN == ISBN;
        }
    }
}
