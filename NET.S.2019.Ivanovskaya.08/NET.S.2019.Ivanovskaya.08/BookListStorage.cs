using Book.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Book
{
    public class BookListStorage: IStorage
    {
        private readonly string fileName;

        public BookListStorage(string fileName)
        {
            this.fileName = fileName;
        }

        public List<Book> LoadBookList()
        {
            var list = new List<Book>();

            try
            {
                using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                using (var reader = new BinaryReader(stream))
                {
                    while (reader.PeekChar() > -1)
                    {
                        list.Add(new Book(reader.ReadString(), reader.ReadString(), reader.ReadString(),
                                          reader.ReadString(), reader.ReadInt32(), reader.ReadInt32(),
                                          reader.ReadDecimal()));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Can't read data from the {nameof(fileName)}", ex);
            }
            return list;
        }

        public void StoreBookList(IEnumerable<Book> list)
        {
            try
            {
                using (var stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write))
                using (var writer = new BinaryWriter(stream))
                {
                    foreach (var book in list)
                    {
                        writer.Write(book.ISBN);
                        writer.Write(book.AuthorName);
                        writer.Write(book.Title);
                        writer.Write(book.Publisher);
                        writer.Write(book.Year);
                        writer.Write(book.NumberOfPages);
                        writer.Write(book.Price);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception($"Can't write data to the {nameof(fileName)}", ex);
            }
        }
    }
}
