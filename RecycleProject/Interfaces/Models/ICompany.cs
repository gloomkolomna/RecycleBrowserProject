using RecycleProject.Enums;
using RecycleProject.Interfaces.Models.Base;
using System.Collections.Generic;

namespace RecycleProject.Interfaces.Models
{
    /// <summary>
    /// Компания по приему отходов
    /// </summary>
    public interface ICompany: ICompanyBase
    {
        IContact Contact { get; set; }
    }
}