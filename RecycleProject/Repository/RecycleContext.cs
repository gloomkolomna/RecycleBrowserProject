using Microsoft.EntityFrameworkCore;
using RecycleProject.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecycleProject.Model;

namespace RecycleProject
{
    public class RecycleContext : DbContext
    {
        public RecycleContext(DbContextOptions<RecycleContext> options)
            : base(options) { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<RecyclePoint> RecyclePoints { get; set; }
    }
}