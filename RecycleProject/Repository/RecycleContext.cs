using Microsoft.EntityFrameworkCore;
using RecycleProject.Interfaces.Models;
using RecycleProject.Model.Entity;

namespace RecycleProject
{
    internal class RecycleContext : DbContext
    {
        public RecycleContext(DbContextOptions<RecycleContext> options)
            : base(options) { }

        public DbSet<CompanyEntity> Companies { get; set; }
        public DbSet<RecyclePointEntity> RecyclePoints { get; set; }
        public DbSet<AddressEntity> Addresses { get; set; }
        public DbSet<ContactEntity> Contacts { get; set; }
        public DbSet<LocationEntity> Locations { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<PointCategoryRelationship> Relationships { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder
                .Entity<PointCategoryRelationship>()
                .HasKey(x => new { x.RecyclePointId, x.CategoryId });

            modelBuilder
                .Entity<RecyclePointEntity>()
                .HasMany(x => x.Rels)
                .WithOne(x => x.RecyclePoint)
                .HasForeignKey(x => x.RecyclePointId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder
                .Entity<CategoryEntity>()
                .HasMany(x => x.Rels)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
        
    }
}