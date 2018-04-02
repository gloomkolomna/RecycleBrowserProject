using Microsoft.EntityFrameworkCore;
using RecycleProject.Interfaces.Models;
using RecycleProject.Model;

namespace RecycleProject
{
    public class RecycleContext : DbContext
    {
        public RecycleContext(DbContextOptions<RecycleContext> options)
            : base(options) { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<RecyclePoint> RecyclePoints { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Relationship> Relationships { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecyclePoint>()
                .HasMany(p => p.Categories)
                .WithOne()
                .HasForeignKey(k => k.Id);


            modelBuilder.Entity<Relationship>()
                .HasOne(h => h.RecyclePoint)
                .WithMany()
                .HasForeignKey(f => f.RecyclePointId)
                .HasForeignKey(fk => fk.CategoryId);


            /*modelBuilder.Entity<RecyclePoint>()
                .HasMany(p => p.Categories
                .HasForeignKey(t => t.Id);*/

            base.OnModelCreating(modelBuilder);
        }
        
    }
}