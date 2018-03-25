using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecycleProject.Interfaces.Models
{
    public interface IContact
    {
        string Phone { get; set; }
        string Web { get; set; }
        string Email { get; set; }
        /// <summary>
        /// Адрес
        /// </summary>
        IAdress Adress { get; set; }
    }
}
