using RecycleProject.Enums;
using System.Collections.Generic;

namespace RecycleProject.Interfaces.Models
{
    /// <summary>
    /// Компания по приему отходов
    /// </summary>
    public interface ICompany
    {
        int Id { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Описание (255 символов)
        /// </summary>
        string Description { get; set; }

        IContact Contact { get; set; }

        /// <summary>
        /// Типы принимаемых отходов
        /// </summary>
        IEnumerable<IRecycleType> RecycleTypes { get; set; }
    }
}