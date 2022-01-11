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
        if (bookToDelete != null
            && bookToDelete.BorrowerLastName == null
            && bookToDelete.BorrowerFirstName == null)
        {
            this._context.Remove(bookToDelete);
            this._context.SaveChanges();
            return true;
        }
        return false;
    }

    public bool DeleteBooks(long[] isbn)
    {
        if (isbn.Length > 0)
        {
            foreach (var isbnNum in isbn)
            {
                Book? match = this._context.Books.Find(isbnNum);
                if (match != null
                    && match.BorrowerLastName == null
                    && match.BorrowerFirstName == null)
                {
                    this._context.Books.Remove(match);
                }
            }
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

    public Book? GetBook(long isbn)
    {
        return this._context.Books.Find(isbn);
    }

    public Book[] GetBorrowedBooks()
    {
        return _context.Books.AsQueryable()
                             .Where(book => book.BorrowerFirstName != null && book.BorrowerLastName != null)
                             .ToArray();
    }

    public Book[] GetBorrowedBooksBy(string name)
    {
        return _context.Books.Where(b => b.BorrowerFirstName != null
                                         && b.BorrowerLastName != null
                                         && (b.BorrowerFirstName + b.BorrowerLastName).Equals(name))
                             .ToArray();
    }

    public bool IsAvailableISBN(long isbn)
    {
        return !this._context.Books.Any(b => b.ISBN == isbn);
    }

    public void LendBooks(Book[] booksToLend)
    {
        foreach (Book book in booksToLend)
        {
            var _book = this._context.Books.Find(book.ISBN);
            if (_book != null)
            {
                _book.BorrowDate = book.BorrowDate;
                _book.BorrowerLastName = book.BorrowerLastName;
                _book.BorrowerFirstName = book.BorrowerFirstName;
                _book.ShouldReturn = book.ShouldReturn;
                this._context.Books.Update(_book);
            }
        }
        this._context.SaveChanges();
    }

    public void ReturnBooks(long[] isbnNumbers)
    {
        foreach (long isbn in isbnNumbers)
        {
            var book = this._context.Books.Find(isbn);
            if (book != null)
            {
                book.ShouldReturn = null;
                book.BorrowDate = null;
                book.BorrowerLastName = null;
                book.BorrowerFirstName = null;
                this._context.Books.Update(book);
            }
        }
        this._context.SaveChanges();
    }

    public Book? UpdateBook(Book bookToUpdate)
    {
        Book? existingBook = this._context.Books.Find(bookToUpdate.ISBN);
        if (existingBook != null)
        {
            existingBook.Title = bookToUpdate.Title;
            existingBook.Publisher = bookToUpdate.Publisher;
            existingBook.ReleaseDate = bookToUpdate.ReleaseDate;
            this._context.Books.Update(existingBook);
            return bookToUpdate;
        }
        return null;
    }
}