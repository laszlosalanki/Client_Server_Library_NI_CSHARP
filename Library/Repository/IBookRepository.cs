using Common;

public interface IBookRepository
{
    Book AddNewBook(Book newBook);
    Book? UpdateBook(Book bookToUpdate);
    bool DeleteBook(long isbn);
    void LendBooks(Book[] booksToLend);
    void ReturnBooks(long[] isbnNumbers);
    Book[] GetBorrowedBooks();
    Book[] GetAvailableBooks();
}