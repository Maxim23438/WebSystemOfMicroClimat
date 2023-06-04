using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using WebSystemOfMicroClimat.Data.Services;
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

            builder.Entity<TempTimeOff>()
              .HasOne(e => e.User)
           .WithOne(e => e.TempTimeOff)
              .HasForeignKey<TempTimeOff>(e => e.UserId);

            builder.Entity<TempTimeOn>()
              .HasOne(e => e.User)
           .WithOne(e => e.TempTimeOn)
              .HasForeignKey<TempTimeOn>(e => e.UserId);

            builder.Entity<LightTimeOff>()
              .HasOne(e => e.User)
           .WithOne(e => e.LightTimeOff)
              .HasForeignKey<LightTimeOff>(e => e.UserId);

            builder.Entity<LightTimeOn>()
              .HasOne(e => e.User)
           .WithOne(e => e.LightTimeOn)
              .HasForeignKey<LightTimeOn>(e => e.UserId);

            builder.Entity<HumTimeOff>()
              .HasOne(e => e.User)
           .WithOne(e => e.HumTimeOff)
              .HasForeignKey<HumTimeOff>(e => e.UserId);

            builder.Entity<HumTimeOn>()
              .HasOne(e => e.User)
           .WithOne(e => e.HumTimeOn)
              .HasForeignKey<HumTimeOn>(e => e.UserId);

            builder.Entity<Review>()
            .HasOne(r => r.User)
            .WithMany(u => u.Reviews)
            .HasForeignKey(r => r.UserId);

            builder.Entity<Admin>();
            base.OnModelCreating(builder);
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Value> Values { get; set; }
        public DbSet<Temp> Temps { get; set; }
        public DbSet<Humidity> Humidities { get; set; }
        public DbSet <Light> Lights { get; set;}
        public DbSet<Admin> Admins { get; set;}
        public DbSet<TempTimeOn> TempsTimeOns { get; set;}
        public DbSet<TempTimeOff> TempsTimeOffs { get; set;}
        public DbSet<LightTimeOn> LightTimeOns { get; set; }
        public DbSet<LightTimeOff> LightTimeOffs { get; set; }
        public DbSet<HumTimeOn> HumTimeOns { get; set; }
        public DbSet<HumTimeOff> HumTimeOffs { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
