using Microsoft.EntityFrameworkCore;
using WebSystemOfMicroClimat.Models;

namespace WebSystemOfMicroClimat.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Value>()
               .HasOne(e => e.User)
            .WithOne(e => e.Value)
               .HasForeignKey<Value>(e => e.UserId);
            base.OnModelCreating(builder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Value> Values { get; set; }
    }
}
