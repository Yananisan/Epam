using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2019.Ivanovskaya._08.Models
{
    public interface IStorage
    {
        void StoreBookList(IEnumerable<Book> list);

        List<Book> LoadBookList();
    }
}
