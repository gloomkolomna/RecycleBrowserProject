using System.Collections.Generic;
using RecycleProject.Model.Enums;
using RecycleProject.Model.Interfaces;

namespace RecycleProject.Model
{
    internal class Company : ICompany
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IContact Contact { get; set; }
        public IEnumerable<IRecycleType> RecycleTypes { get; set; }
        public IEnumerable<IRecyclePoint> RecyclePoints { get; set; }
    }
}