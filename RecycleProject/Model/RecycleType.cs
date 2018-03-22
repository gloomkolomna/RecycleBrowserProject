using RecycleProject.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecycleProject.Model
{
    internal class RecycleType : IRecycleType
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
