using RecycleProject.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecycleProject.Model
{
    public class Contact: IContact
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Web { get; set; }
        public string Email { get; set; }
        public IAddress Address { get; set; }
    }
}
