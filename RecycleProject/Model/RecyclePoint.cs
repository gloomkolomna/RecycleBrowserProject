using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RecycleProject.Enums.Model;
using RecycleProject.Interfaces.Models;
using System.Collections.Generic;

namespace RecycleProject.Model
{
    public class RecyclePoint: IRecyclePoint
    {
        public int Id { get; set; }
        public ILocation Location { get; set; }
        public IEnumerable<ICategory> Categories { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Days WorkDays { get; set; }
        public ICompany Company { get; set; }
    }
}
