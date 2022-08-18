using Microsoft.EntityFrameworkCore;
using System.Numerics;
using TesteTecnicoKNEWIN.Models;

namespace TesteTecnicoKNEWIN.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
