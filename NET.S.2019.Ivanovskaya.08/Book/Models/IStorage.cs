using System.Collections.Generic;

namespace Book.Models
{
    public interface IStorage
    {
        void StoreBookList(IEnumerable<Book> list);

        List<Book> LoadBookList();
    }
}
