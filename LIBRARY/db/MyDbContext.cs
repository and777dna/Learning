using Microsoft.EntityFrameworkCore;

namespace LIBRARY.db;

public class MyDbContext : DbContext
{
    public DbSet<Book> Book { get; set; }
    //public DbSet<Reader>? Reader { get; set; }
    
    /*public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }*/
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql("Server=localhost;Database=library;User=root;Password=root;Port=3308;",
                new MySqlServerVersion(new Version(8, 0, 21)));
        }
    }
}

