using Game.Models;
using Microsoft.EntityFrameworkCore;

namespace Game.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=library;user=user;password=password");
        }
        public DbSet<Player> Players { get; set; }
        public DbSet<Building> Buildings { get; set; }
    }
}