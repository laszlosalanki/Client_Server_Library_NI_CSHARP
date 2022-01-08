using Common;

internal class BooksService
{
    private static BooksService _instance;
    private BooksDB _db;
    public static BooksService getInstance { get { return _instance; } }
    public BooksService(BooksDB db) {

        _instance = this;
        this._db = db;
    }

    public Book? Test()
    {
        var book = new Book(1, "test", "test2", "test3", DateTime.Now, null, null, null, null);
        _db.Books.Add(book);
       return _db.Books.Find((long)1);
    }
}