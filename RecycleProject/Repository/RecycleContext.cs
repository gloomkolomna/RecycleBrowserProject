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
        public DbSet<RecycleType> RecycleTypes { get; set; }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
             .HasBaseType<IContact>();

            base.OnModelCreating(modelBuilder);
        }*/
        
    }
}