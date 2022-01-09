using Common;

public static class BookValidator
{
    public static Book? ValidateBook(Book book)
    {
        // TODO
        if (book != null
            && book.ISBN > 0 && book.ISBN.ToString().Length == 13
            && book.Title.Trim().Length > 0)
        {
            return book;
        }
        return null;
    }
}