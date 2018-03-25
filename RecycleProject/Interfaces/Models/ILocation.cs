namespace RecycleProject.Interfaces.Models
{
    /// <summary>
    /// Положение
    /// </summary>
    public interface ILocation
    {
        /// <summary>
        /// Долгота
        /// </summary>
        double Longitude { get; set; }
        /// <summary>
        /// Широта
        /// </summary>
        double Latitude { get; set; }
    }
}