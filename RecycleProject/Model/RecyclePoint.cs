using System.Collections.Generic;
using RecycleProject.Model.Enums;
using RecycleProject.Model.Interfaces;

namespace RecycleProject.Model
{
    internal class RecyclePoint : IRecyclePoint
    {
        public int Id { get; set; }
        public ILocation Location { get; set; }
        public IEnumerable<IRecycleType> Types { get; set; }
        public IEnumerable<Days> WorkDays { get; set; }
        public ICompany Company { get; set; }
    }
}
