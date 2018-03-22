using Microsoft.EntityFrameworkCore;
using RecycleProject.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecycleProject
{
    public class RecycleContext: DbContext
    {
        public DbSet<ICompany> Companies { get; set; }
        public DbSet<IRecyclePoint> RecyclePoints { get; set; }
    }
}
