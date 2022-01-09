using Common;
using Microsoft.EntityFrameworkCore;

public class BookRepository : IBookRepository
{
    private readonly BookContext _context;
    public BookRepository(BookContext context)
    {
        this._context = context;
    }

    public Book addNewBook(Book newBook)
    {
        throw new NotImplementedException();
    }

    public List<Book> getAvailableBooks()
    {
        var book = new Book((long)1, "asd", "asd", "asd", DateTime.Now, null, null, null, null);
        var list = new List<Book>();
        list.Add(book);
        return list;
    }

    public List<Book> getBorrowedBooks()
    {
        throw new NotImplementedException();
    }

    public Book updateBook(Book bookToUpdate)
    {
        throw new NotImplementedException();
    }
}