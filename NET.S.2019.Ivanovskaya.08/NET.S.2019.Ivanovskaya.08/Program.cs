using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book
{
    class Program
    {
        static void Main(string[] args)
        {
            BookListStorage bookStorage = new BookListStorage(" ");
            BookListService bookService = new BookListService(bookStorage);

            bookService.AddBook(new Book("123456789", "Tolkien", "LOTR", "Russia", 1954, 2000, 100));
            bookService.AddBook(new Book("123456788", "Palanik", "Choke", "Russia", 2001, 336, 50));
            bookService.AddBook(new Book("123456788", "Palanik2", "Choke", "Russia", 2001, 336, 50));

            Print(bookService.FindBookByTag(new TitlePredicate("Choke")).ToList());

            Console.ReadKey();
        }

        public static void Print(List<Book> books)
        {
            foreach (var book in books)
                Console.WriteLine(book);
            Console.WriteLine();
        }
    }
}
