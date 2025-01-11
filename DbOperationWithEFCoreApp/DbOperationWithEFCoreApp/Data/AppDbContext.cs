using DbOperationWithEFCoreApp.Entities;
using Microsoft.EntityFrameworkCore;
namespace DbOperationWithEFCoreApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options):base(options) { }

        public DbSet<Language> Language { get; set; }
        public DbSet<CurrencyType> CurrencyType { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Price> Price { get; set; }
    }
}
