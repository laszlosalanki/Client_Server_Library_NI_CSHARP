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
        //var list = new List<Book>();
        //list.Add(_context.Books.First());
        return _context.Books.AsQueryable().ToList();
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