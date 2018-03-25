using System;

namespace RecycleProject.Enums
{
    [Flags]
    public enum Days
    {
        None = 0x00,
        /// <summary>
        /// Понедельник
        /// </summary>
        Monday = 0x01,
        /// <summary>
        /// Вторник
        /// </summary>
        Tuesday = 0x02,
        /// <summary>
        /// Среда
        /// </summary>
        Wednesday = 0x04,
        /// <summary>
        /// Четверг
        /// </summary>
        Thursday = 0x08,
        /// <summary>
        /// Пятница
        /// </summary>
        Friday = 0x10,
        /// <summary>
        /// Суббота
        /// </summary>
        Saturday = 0x20,
        /// <summary>
        /// Воскресенье
        /// </summary>
        Sunday = 0x40
    }
}