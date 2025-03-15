using DbOperationWithEFCoreApp.Entities;
using Microsoft.EntityFrameworkCore;
namespace DbOperationWithEFCoreApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>().HasData(
                new Language() { Id=1, Title="English", Description="English"},
                new Language() { Id=2, Title="Hindi", Description="Hindi"},
                new Language() { Id=3, Title= "Spanish", Description= "Spanish" },
                new Language() { Id=4, Title= "Arabic", Description= "Arabic" },
                new Language() { Id=5, Title= "Japanese", Description= "Japanese" }
                );

            modelBuilder.Entity<CurrencyType>().HasData(
                new CurrencyType() { Id = 1, Title = "USD", Description = "United States Dollar" },
                new CurrencyType() { Id = 2, Title = "EUR", Description = "Euro " },
                new CurrencyType() { Id = 3, Title = "INR", Description = "Indian Rupee" },
                new CurrencyType() { Id = 4, Title = "JPY", Description = "Japanese Yen" },
                new CurrencyType() { Id = 5, Title = "GBP", Description = "British Pound Sterling" },
                new CurrencyType() { Id = 6, Title = "CNY", Description = "Chinese Yuan Renminbi" },
                new CurrencyType() { Id = 7, Title = "AUD", Description = "Australian Dollar" }
                );

            modelBuilder.Entity<Address>().HasData(
                new Address() { Id = 1, City = "Mumbai", State = "Maharashtra", PostalCode = "400086", Country = "India" },
                new Address() { Id = 2, City = "Pune", State = "Maharashtra", PostalCode = "411001", Country = "India" },
                new Address() { Id = 3, City = "Delhi", State = "Delhi", PostalCode = "110001", Country = "India" },
                new Address() { Id = 4, City = "Bengaluru", State = "Karnataka", PostalCode = "560001", Country = "India" },
                new Address() { Id = 5, City = "Chennai", State = "Tamil Nadu", PostalCode = "600001", Country = "India" },
                new Address() { Id = 6, City = "Hyderabad", State = "Telangana", PostalCode = "500001", Country = "India" }
            );

        }





        public DbSet<Language> Language { get; set; }
        public DbSet<CurrencyType> CurrencyType { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Price> Price { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
