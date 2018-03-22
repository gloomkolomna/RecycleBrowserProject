using System.ComponentModel.DataAnnotations;
using RecycleProject.Model.Interfaces;

namespace RecycleProject.Model
{
    public class Adress
    {
        [Key]
        public int Id { get; set; }
        public int Index { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Home { get; set; }
    }
}