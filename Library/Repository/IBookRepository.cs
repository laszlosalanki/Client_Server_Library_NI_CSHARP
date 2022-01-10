using Common;

public interface IBookRepository
{
    Book? GetBook(long isbn);
    Book AddNewBook(Book newBook);
    Book? UpdateBook(Book bookToUpdate);
    bool DeleteBook(long isbn);
    bool DeleteBooks(long[] isbn);
    bool IsAvailableISBN(long isbn);
    void LendBooks(Book[] booksToLend);
    void ReturnBooks(long[] isbnNumbers);
    Book[] GetBorrowedBooks();
    Book[] GetBorrowedBooksBy(string name);
    Book[] GetAvailableBooks();
}