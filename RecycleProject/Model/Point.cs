using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RecycleProject.Enums;

namespace RecycleProject.Model
{
    [Table("Point")]
    public class Point
    {
        [Key]
        public int Id { get; set; }
        public Location Location { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Days WorkDays { get; set; }
        public Company Company { get; set; }
    }
}
