using DbOperationWithEFCoreApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace DbOperationWithEFCoreApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookPrice> BookPrices { get; set; }
        public DbSet<CurrencyType> CurrencyTypes { get; set; }
        public DbSet<Language> Languages { get; set; }

    }
}
