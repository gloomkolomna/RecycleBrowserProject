﻿using System;

namespace RecycleProject.Enums.Model
{
    [Flags]
    public enum Days
    {
        None = 0,
        /// <summary>
        /// Понедельник
        /// </summary>
        Monday = 1 << 0,
        /// <summary>
        /// Вторник
        /// </summary>
        Tuesday = 1 << 1,
        /// <summary>
        /// Среда
        /// </summary>
        Wednesday = 1 << 2,
        /// <summary>
        /// Четверг
        /// </summary>
        Thursday = 1 << 3,
        /// <summary>
        /// Пятница
        /// </summary>
        Friday = 1 << 4,
        /// <summary>
        /// Суббота
        /// </summary>
        Saturday = 1 << 5,
        /// <summary>
        /// Воскресенье
        /// </summary>
        Sunday = 1 << 6
    }
}