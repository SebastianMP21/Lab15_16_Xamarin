using LocalDatabase.Models;
using Microsoft.EntityFrameworkCore;

namespace LocalDatabase.DataContext
{
    public class AppDbContext : DbContext
    {
        string DbPath = string.Empty;

        public AppDbContext(string dbPath)
        {
            this.DbPath = dbPath;
        }

        public DbSet<Student> Students { get; set; }
        


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={DbPath}");

        }
    }
}

