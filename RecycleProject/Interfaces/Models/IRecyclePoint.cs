using RecycleProject.Enums;
using RecycleProject.Interfaces.Models.Base;
using System.Collections.Generic;

namespace RecycleProject.Interfaces.Models
{
    /// <summary>
    /// Пункт приема
    /// </summary>
    public interface IRecyclePoint: IRecyclePointBase
    {
        ILocation Location { get; set; }
        IEnumerable<ICategory> Categories { get; set; }
        ICompany Company { get; set; }
    }
}