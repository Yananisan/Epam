namespace Book.Models
{
    public interface IPredicate<T>
    {
        bool IsMatch(T tag);
    }
}
