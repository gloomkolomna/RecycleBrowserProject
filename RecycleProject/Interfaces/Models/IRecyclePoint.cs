using RecycleProject.Enums;
using System.Collections.Generic;

namespace RecycleProject.Interfaces.Models
{
    /// <summary>
    /// Пункт приема
    /// </summary>
    public interface IRecyclePoint
    {
        int Id { get; set; }
        ILocation Location { get; set; }
        IEnumerable<IRecycleType> Types { get; set; }
        Days WorkDays { get; set; }
        ICompany Company { get; set; }
    }
}