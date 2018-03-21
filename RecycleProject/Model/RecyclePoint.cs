using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecycleProject.Model.Enums;
using RecycleProject.Model.Interfaces;

namespace RecycleProject.Model
{
    internal class RecyclePoint : IRecyclePoint
    {
        public RecyclePoint()
        {

        }

        public string Name { get; set; }
        public ILocation Location { get; set; }
        public RecycleType[] Types { get; set; }
        public string Description { get; set; }
    }
}
