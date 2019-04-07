using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NET.S._2019.Ivanovskaya._08.Models;

namespace NET.S._2019.Ivanovskaya._08
{
    public class BookListService: ISortable<IComparer<Book>>, IFindable<IPredicate<Book>>, IEnumerable<Book>
    {     
        private List<Book> bookList = new List<Book>();
        private readonly BookListStorage bookStorage;

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

        }

        public void RemoveBook(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                throw new ArgumentNullException();
            }
            bookList.Remove(book);
        }

        public IEnumerable<Book> FindBookByTag(IPredicate<Book> predicate)
        {
            if (ReferenceEquals(predicate, null))
            {
                throw new ArgumentNullException();
            }

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
            bookStorage.StoreBookList(bookList);
        }

        public List<Book> GetAllBooks()
        {
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
    }
}
