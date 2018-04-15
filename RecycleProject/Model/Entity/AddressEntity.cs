using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RecycleProject.Interfaces.Models;
using RecycleProject.Interfaces.Models.Entity;

namespace RecycleProject.Model.Entity
{
    [Table("Address")]
    internal class AddressEntity : IAddressEntity
    {
        [Key]
        public int Id { get; set; }
        public string Street { get; set; }
        public string Home { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string Index { get; set; }

        public static implicit operator AddressEntity(Address address)
        {
            if (address == null) return null;

            var addrss = new AddressEntity
            {
                Id = address.Id,
                Street = address.Street,
                Home = address.Home,
                City = address.City,
                Region = address.Region,
                Country = address.Country,
                Index = address.Index
            };

            return addrss;
        }

        public static implicit operator Address(AddressEntity addressEntity)
        {
            if (addressEntity == null) return null;

            var addrss = new Address
            {
                Id = addressEntity.Id,
                Street = addressEntity.Street,
                Home = addressEntity.Home,
                City = addressEntity.City,
                Region = addressEntity.Region,
                Country = addressEntity.Country,
                Index = addressEntity.Index
            };

            return addrss;
        }
    }
}