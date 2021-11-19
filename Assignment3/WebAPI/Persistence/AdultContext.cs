using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Persistence {
    public class AdultContext : DbContext {
        public DbSet<Adult> Adults { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            // name of database
            optionsBuilder.UseSqlite(@"Data Source = D:\repos\via-ste-dnp1\Assignment3\WebAPI\Adults.db");
        }
    }
}