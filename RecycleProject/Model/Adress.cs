using RecycleProject.Model.Interfaces;

namespace RecycleProject.Model
{
    internal class Adress : IAdress
    {
        public int Index { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Home { get; set; }
    }
}