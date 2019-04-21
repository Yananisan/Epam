namespace Book
{
    public static class BookFormatting
    {
        public static string AuthorTitle(this Book book)
        {
            return $"{book.AuthorName}, {book.Title}";
        }

        public static string AuthorTitlePubYear(this Book book)
        {
            return $"{book.AuthorName}, {book.Title}, {book.Publisher}, {book.Year}";
        }
    }
}
