using RecycleProject.Model.Enums;
using RecycleProject.Model.Interfaces;

namespace RecycleProject.Model
{
    public class Company : ICompany
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Web { get; set; }
        public string Email { get; set; }
        public RecycleType[] RecycleTypes { get; set; }
        public CompanyGraphics[] CompanyGraphicses { get; set; }
        public IRecyclePoint[] RecyclePoints { get; set; }
    }
}