using Common;

public interface IBookRepository
{
    Book addNewBook(Book newBook);
    Book updateBook(Book bookToUpdate);
    List<Book> getBorrowedBooks();
    List<Book> getAvailableBooks();
}