using System.Collections.Generic;

namespace NET.S._2019.Ivanovskaya._08.Models
{
    public interface IFindable<T>
    {
        IEnumerable<Book> FindBookByTag(T value);
    }
}
