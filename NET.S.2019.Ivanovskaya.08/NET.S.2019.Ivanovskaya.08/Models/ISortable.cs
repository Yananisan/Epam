namespace Book.Models
{
    public interface ISortable<T>
    {
        void SortBooksByTag(T value);
    }
}
