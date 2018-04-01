using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RecycleProject.Enums;
using RecycleProject.Interfaces.Models;

namespace RecycleProject.Model
{
    [Table("RecyclePoint")]
    public class RecyclePoint// : IRecyclePoint
    {
        [Key]
        public int Id { get; set; }
        public Location Location { get; set; }
        public IEnumerable<RecycleType> Types { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Days WorkDays { get; set; }
        public Company Company { get; set; }
    }
}
