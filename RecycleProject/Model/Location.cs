using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecycleProject.Model.Interfaces;

namespace RecycleProject.Model
{
    internal class Location : ILocation
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
