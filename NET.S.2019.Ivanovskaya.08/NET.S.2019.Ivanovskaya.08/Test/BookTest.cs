using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;

namespace Book.Test
{
    [TestFixture]
    public class BookTest
    {
        Book b1 = new Book("123456789", "Tolkien", "LOTR", "Russia", 1954, 2000, 100);
        Book b2 = new Book("123456788", "Palanik", "Choke", "Russia", 2001, 336, 50);
        Book b3 = new Book("123456788", "Palanik2", "Choke", "Russia", 2001, 336, 50);

        [Test]
        public void Add()
        {
            BookListStorage bookStorage = new BookListStorage(" ");
            List<Book> expected = new List<Book>();
            expected.Add(b1);
            expected.Add(b2);
            expected.Add(b3);
            BookListService actual = new BookListService(bookStorage);
            actual.AddBook(b1);
            actual.AddBook(b2);
            actual.AddBook(b3);
            Assert.AreEqual(expected, actual.GetList);
        }

        [Test]
        public void Print()
        {
            string expected = "ISBN: 123456789, AuthorName: Tolkien, Title: LOTR, Publisher: Russia, Year: 1954, Number of pages: 2000, Price: 100";
            BookListStorage bookStorage = new BookListStorage(" ");
            BookListService actual = new BookListService(bookStorage);
            actual.AddBook(b1);
            Assert.AreEqual(expected, actual.Print());
        }

        [Test]
        public void AuthorTitle()
        {
            string expected = "Tolkien, LOTR";
            BookListStorage bookStorage = new BookListStorage(" ");
            BookListService actual = new BookListService(bookStorage);
            Assert.AreEqual(expected, b1.AuthorTitle());
        }

        [Test]
        public void Test_Book_Print_AuthorNamePrice()
        {
            string expected = "Tolkien, LOTR, Russia, 1954";
            BookListStorage bookStorage = new BookListStorage(" ");
            BookListService actual = new BookListService(bookStorage);
            Assert.AreEqual(expected, b1.AuthorTitlePubYear());
        }
    }
}
