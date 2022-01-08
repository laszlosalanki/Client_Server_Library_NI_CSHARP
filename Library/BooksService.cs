internal class BooksService
{
    private static BooksService? _instance;
    public static BooksService GetInstance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new BooksService();
            }
            return _instance;
        }
    }

    public string SayHello() {
        return "Hello world.";
    }
}