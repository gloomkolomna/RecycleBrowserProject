using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RecycleProject.Model.Enums;
using RecycleProject.Model.Interfaces;

namespace RecycleProject.Model
{
    public class RecyclePoint
    {
        [Key]
        public int Id { get; set; }
        public Location Location { get; set; }
        public IEnumerable<RecycleType> Types { get; set; }
        [NotMapped]
        public IEnumerable<Days> WorkDays { get; set; }
        public Company Company { get; set; }
    }
}
