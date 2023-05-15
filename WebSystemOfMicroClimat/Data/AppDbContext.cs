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
            builder.Entity<Temp>()
               .HasOne(e => e.User)
            .WithOne(e => e.Temp)
               .HasForeignKey<Temp>(e => e.UserId);
            builder.Entity<Humidity>()
               .HasOne(e => e.User)
            .WithOne(e => e.Humidity)
               .HasForeignKey<Humidity>(e => e.UserId);
            builder.Entity<Light>()
              .HasOne(e => e.User)
           .WithOne(e => e.Light)
              .HasForeignKey<Light>(e => e.UserId);
            base.OnModelCreating(builder);
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Value> Values { get; set; }
        public DbSet<Temp> Temps { get; set; }
        public DbSet<Humidity> Humidities { get; set; }
        public DbSet <Light> Lights { get; set;}
    }
}
