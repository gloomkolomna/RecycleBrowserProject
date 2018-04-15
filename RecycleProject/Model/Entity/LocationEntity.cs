using RecycleProject.Interfaces.Models.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecycleProject.Model.Entity
{
    [Table("location")]
    internal class LocationEntity : ILocationEntity
    {
        [Key]
        public int Id { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public static implicit operator LocationEntity(Location location)
        {
            if (location == null) return null;

            var loc = new LocationEntity
            {
                Id = location.Id,
                Longitude = location.Longitude,
                Latitude = location.Latitude
            };

            return loc;
        }

        public static implicit operator Location(LocationEntity locationEntity)
        {
            if (locationEntity == null) return null;

            var loc = new Location
            {
                Id = locationEntity.Id,
                Longitude = locationEntity.Longitude,
                Latitude = locationEntity.Latitude
            };

            return loc;
        }
    }

}
