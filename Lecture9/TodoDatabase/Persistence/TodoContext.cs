using Microsoft.EntityFrameworkCore;
using TodoDatabase.Models;

namespace TodoDatabase.Persistence {
    public class TodoContext : DbContext {
        
        public DbSet<Todo> Todos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite(@"Data Source = D:\repos\via-ste-dnp1\Lecture9\TodoDatabase\TodoDatabase.db");
        }
    }
}