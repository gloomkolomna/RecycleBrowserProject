using RecycleProject.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecycleProject.Model
{
    public class Address : IAddress
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Home { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string Index { get; set; }
    }
}
