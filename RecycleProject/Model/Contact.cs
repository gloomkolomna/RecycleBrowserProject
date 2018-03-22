using RecycleProject.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecycleProject.Model
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Web { get; set; }
        public string Email { get; set; }
        public Adress Adress { get; set; }
    }
}
