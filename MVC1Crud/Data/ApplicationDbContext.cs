using Microsoft.EntityFrameworkCore;
using MVC1Crud.Models;

namespace MVC1Crud.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Group> Groups { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Store>()
                .HasOne(s => s.Group)
                .WithMany(g => g.Stores)
                .HasForeignKey(s => s.GroupId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Store)
                .WithMany(s => s.Users)
                .HasForeignKey(u => u.StoreId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Group)
                .WithMany(g => g.Users)
                .HasForeignKey(u => u.GroupId)
              .OnDelete(DeleteBehavior.Restrict);
        }

    }
}