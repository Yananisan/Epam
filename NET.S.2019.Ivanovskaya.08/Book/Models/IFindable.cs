using System.Collections.Generic;

namespace Book.Models
{
    public interface IFindable<T>
    {
        IEnumerable<Book> FindBookByTag(T value);
    }
}
