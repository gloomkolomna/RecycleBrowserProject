using RecycleProject.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecycleProject.Model
{
    internal class Contact : IContact
    {
        public string Phone { get; set; }
        public string Web { get; set; }
        public string Email { get; set; }
        public IAdress Adress { get; set; }
    }
}
