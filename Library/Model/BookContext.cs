using Common;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

public class BookContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public BookContext([NotNullAttribute] DbContextOptions options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Book>();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer();
    }
}