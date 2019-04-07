namespace NET.S._2019.Ivanovskaya._08.Models
{
    public interface IPredicate<T>
    {
        bool IsMatch(T tag);
    }
}
