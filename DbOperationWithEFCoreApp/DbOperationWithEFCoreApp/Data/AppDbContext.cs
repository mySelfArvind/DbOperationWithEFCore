using Microsoft.EntityFrameworkCore;
namespace DbOperationWithEFCoreApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options):base(options) { }
    }
}
