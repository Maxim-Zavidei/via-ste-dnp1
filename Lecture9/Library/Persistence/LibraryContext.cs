using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistence {
    public class LibraryContext : DbContext {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite(@"Data Source = D:\repos\via-ste-dnp1\Lecture9\Library\Library.db");
        }
    }
}