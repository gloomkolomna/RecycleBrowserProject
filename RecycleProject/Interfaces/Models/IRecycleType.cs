using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecycleProject.Interfaces.Models
{
    public interface IRecycleType
    {
        string Name { get; set; }
        string Description { get; set; }
    }
}
