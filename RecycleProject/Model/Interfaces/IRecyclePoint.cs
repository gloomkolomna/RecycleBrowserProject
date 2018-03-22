﻿using RecycleProject.Model.Enums;
using System.Collections.Generic;

namespace RecycleProject.Model.Interfaces
{
    /// <summary>
    /// Пункт приема
    /// </summary>
    public interface IRecyclePoint
    {
        int Id { get; set; }
        /// <summary>
        /// Положение точки
        /// </summary>
        ILocation Location { get; set; }
        /// <summary>
        /// Типы принимаемых отходов
        /// </summary>
        IEnumerable<IRecycleType> Types { get; set; }

        IEnumerable<Days> WorkDays { get; set; }

        /// <summary>
        /// Компания
        /// </summary>
        ICompany Company { get; set; }
    }
}