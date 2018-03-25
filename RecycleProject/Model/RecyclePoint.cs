using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RecycleProject.Enums;

namespace RecycleProject.Model
{
    [Table("RecyclePoint")]
    public class RecyclePoint
    {
        [Key]
        public int Id { get; set; }
        public int LocationId { get; set; }
        [ForeignKey("LocationId")]
        public Location Location { get; set; }
        public IEnumerable<RecycleType> Types { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Days WorkDays { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
    }
}
