using Common;
using Microsoft.EntityFrameworkCore;

public class BooksDB : DbContext
{
    public BooksDB(DbContextOptions<BooksDB> options) : base(options) { }

    public DbSet<Book> Books { get; set; }
}