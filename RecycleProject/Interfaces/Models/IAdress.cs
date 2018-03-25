namespace RecycleProject.Interfaces.Models
{
    /// <summary>
    /// Адрес
    /// </summary>
    public interface IAdress
    {
        /// <summary>
        /// Индекс
        /// </summary>
        int Index { get; set; }
        /// <summary>
        /// Город
        /// </summary>
        string City { get; set; }
        /// <summary>
        /// Улица
        /// </summary>
        string Street { get; set; }
        /// <summary>
        /// Дом
        /// </summary>
        string Home { get; set; }
    }
}