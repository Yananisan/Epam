using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Book.Models;
using NLog;

namespace Book
{
    public class BookListService: ISortable<IComparer<Book>>, IFindable<IPredicate<Book>>, IEnumerable<Book>
    {     
        private List<Book> bookList = new List<Book>();
        private readonly BookListStorage bookStorage;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public BookListService(BookListStorage bookStorage)
        {
            if (ReferenceEquals(bookStorage, null))
            {
                throw new ArgumentException();
            }
            this.bookStorage = bookStorage;

        }

        public void AddBook(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                throw new ArgumentNullException();
            }

            bookList.Add(book);
            logger.Info("Add book in service list " + book);

        }

        public void RemoveBook(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                throw new ArgumentNullException();
            }
            bookList.Remove(book);
            logger.Info("Remove book from service list " + book);
        }

        public IEnumerable<Book> FindBookByTag(IPredicate<Book> predicate)
        {
            if (ReferenceEquals(predicate, null))
            {
                throw new ArgumentNullException();
            }
            logger.Info("Find book with predicate" + predicate);
            return bookList.Where(predicate.IsMatch).ToList();

        }

        public void SortBooksByTag(IComparer<Book> comparer)
        {
            if (ReferenceEquals(comparer, null))
            {
                throw new ArgumentNullException();
            }

            bookList.Sort(comparer);
        }

        public void Save()
        {
            logger.Info("Save book list");
            bookStorage.StoreBookList(bookList);
        }

        public List<Book> GetAllBooks()
        {
            logger.Info("Load book list");
            return bookStorage.LoadBookList();
        }

        public IEnumerator<Book> GetEnumerator()
        {
            foreach (Book book in bookList)
            {
                yield return book;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public List<Book> GetList
        {
            get
            {
                return bookList;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    bookList = value;
                }
            }
        }

        public string Print()
        {
            string result = string.Empty;

            foreach (Book book in bookList)
            {
                result += book.ToString();
            }

            return result;
        }
    }
}
