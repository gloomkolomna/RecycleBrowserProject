using RecycleProject.Model.Enums;

namespace RecycleProject.Model.Interfaces
{
    /// <summary>
    /// Компания по приему отходов
    /// </summary>
    public interface ICompany
    {
        /// <summary>
        /// Наименование
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Описание (255 символов)
        /// </summary>
        string Description { get; set; }
        /// <summary>
        /// Телефон
        /// </summary>
        string Phone { get; set; }
        /// <summary>
        /// Сайт
        /// </summary>
        string Web { get; set; }
        /// <summary>
        /// Электронная почта
        /// </summary>
        string Email { get; set; }
        /// <summary>
        /// Типы принимаемых отходов
        /// </summary>
        RecycleType[] RecycleTypes { get; set; }
        /// <summary>
        /// График работы
        /// </summary>
        CompanyGraphics[] CompanyGraphicses { get; set; }

        /// <summary>
        /// Точки размещения компании
        /// </summary>
        IRecyclePoint[] RecyclePoints { get; set; }
    }
}