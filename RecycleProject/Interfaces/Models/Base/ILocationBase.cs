namespace RecycleProject.Interfaces.Models.Base
{
    public interface ILocationBase
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
