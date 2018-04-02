using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RecycleProject.Enums;
using RecycleProject.Interfaces.Models;

namespace RecycleProject.Model
{
    [Table("Company")]
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Contact Contact { get; set; }
    }
}