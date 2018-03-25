using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RecycleProject.Interfaces.Models;

namespace RecycleProject.Model
{
    [Table("Address")]
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public int Index { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Home { get; set; }
    }
}