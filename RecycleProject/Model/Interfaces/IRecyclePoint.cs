using RecycleProject.Model.Enums;

namespace RecycleProject.Model.Interfaces
{
    /// <summary>
    /// Пункт приема
    /// </summary>
    public interface IRecyclePoint
    {
        /// <summary>
        /// Название точки
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Описание точки
        /// </summary>
        string Description { get; set; }
        /// <summary>
        /// Положение точки
        /// </summary>
        ILocation Location { get; set; }

        /// <summary>
        /// Типы принимаемых отходов
        /// </summary>
        RecycleType[] Types { get; set; }
    }
}