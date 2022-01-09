using Common;

public class BookRepository : IBookRepository
{
    private readonly BookContext _context;
    public BookRepository(BookContext context)
    {
        this._context = context;
    }

    public Book AddNewBook(Book newBook)
    {
        this._context.Books.Add(newBook);
        this._context.SaveChanges();
        return newBook;
    }

    public bool DeleteBook(long isbn)
    {
        Book? bookToDelete = this._context.Books.Find(isbn);
        if (bookToDelete != null)
        {
            this._context.Remove(bookToDelete);
            this._context.SaveChanges();
            return true;
        }
        return false;
    }

    public Book[] GetAvailableBooks()
    {
        return _context.Books.AsQueryable()
                             .Where(book => book.BorrowerFirstName == null && book.BorrowerLastName == null)
                             .ToArray();
    }

    public Book[] GetBorrowedBooks()
    {
        return _context.Books.AsQueryable()
                             .Where(book => book.BorrowerFirstName != null && book.BorrowerLastName != null)
                             .ToArray();
    }

    public void LendBooks(Book[] booksToLend)
    {
        foreach (Book book in booksToLend)
        {
            var _book = this._context.Books.Find(book.ISBN);
            if (_book != null)
            {
                this._context.Books.Update(book);
            }
        }
        this._context.SaveChanges();
    }

    public void ReturnBooks(long[] isbnNumbers)
    {
        foreach (long isbn in isbnNumbers)
        {
            var _book = this._context.Books.Find(isbn);
            if (_book != null)
            {
                _book.ShouldReturn = null;
                _book.BorrowDate = null;
                _book.BorrowerLastName = null;
                _book.BorrowerLastName = null;
                this._context.Books.Update(_book);
            }
        }
        this._context.SaveChanges();
    }

    public Book? UpdateBook(Book bookToUpdate)
    {
        Book? existingBook = this._context.Books.Find(bookToUpdate.ISBN);
        if (existingBook != null)
        {
            this._context.Update(bookToUpdate);
            this._context.SaveChanges();
            return bookToUpdate;
        }
        return null;
    }
}