using Common;

public static class BookValidator
{
    public static bool IsBookValid(Book book)
    {
        if (book.ISBN < 0)
            return false;
        if (book.ISBN.ToString().Length != 13)
            return false;
        string specialChars = "~^×#${}|<>";
        if (ContainsCharacters(book.Title, specialChars))
            return false;
        if (book.BorrowDate != null && book.ShouldReturn != null)
        {
            if (book.BorrowDate >= book.ShouldReturn)
                return false;
        }
        specialChars = "~^^!×_()@#$%*{}[]\\|/<>;:!+";
        if (book.BorrowerLastName != null)
        {
            if (ContainsCharacters(book.BorrowerLastName, specialChars)) 
                return false;
        }
        if (book.BorrowerFirstName != null)
        {
            if (ContainsCharacters(book.BorrowerFirstName, specialChars))
                return false;
        }
        return true;
    }

    private static bool ContainsCharacters(string text, string charactersToCheck)
    {
        return charactersToCheck.Where(x => text.Contains(x)).Any();
    }
}