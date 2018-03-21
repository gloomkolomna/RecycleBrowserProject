using RecycleProject.Model.Enums;
using RecycleProject.Model.Interfaces;

namespace RecycleProject.Model
{
    internal class RecyclePoint : IRecyclePoint
    {
        public string Name { get; set; }
        public ILocation Location { get; set; }
        public RecycleType[] Types { get; set; }
        public ICompany Company { get; set; }
        public string Description { get; set; }
    }
}
