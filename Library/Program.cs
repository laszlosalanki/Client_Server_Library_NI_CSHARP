using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IBookRepository, BookRepository>();

builder.Services.AddMvc();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllers();
builder.Services.AddDbContext<BookContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlDb")));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

app.Run();