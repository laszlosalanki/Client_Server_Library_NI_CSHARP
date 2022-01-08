var builder = WebApplication.CreateBuilder(args);

// init service
var booksService = BooksService.GetInstance;

var app = builder.Build();

app.MapGet("test", () =>
{
    return booksService.SayHello();
});

app.Run();
