using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecycleProject.Model
{
    public class RecyclePoint
    {
        public RecyclePoint()
        {

        }

        public string Name { get; set; }
        public Location Location { get; set; }
        public string Description { get; set; }
    }
}
