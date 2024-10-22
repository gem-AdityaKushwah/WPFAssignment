using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace WPFAssignment.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserDetails> UserDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Use the connection string from app.config
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\localInstance;Initial Catalog=WPFAssignment;Integrated Security=True");
        }
    }
    }
}
