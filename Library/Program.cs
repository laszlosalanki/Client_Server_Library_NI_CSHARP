using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BooksDB>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlDbConnect")))
                .AddTransient<BooksService>();

var service = BooksService.getInstance;
var app = builder.Build();

app.MapGet("test", () =>
{

});

app.Run();