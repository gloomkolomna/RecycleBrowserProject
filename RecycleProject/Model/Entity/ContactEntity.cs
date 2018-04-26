using RecycleProject.Interfaces.Models.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecycleProject.Model.Entity
{
    [Table("contact")]
    internal class ContactEntity: IContactEntity
    {
        [Key]
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Web { get; set; }
        public string Email { get; set; }
        public AddressEntity Address { get; set; }

        public static implicit operator ContactEntity(Contact contact)
        {
            if (contact == null) return null;

            var contct = new ContactEntity
            {
                Id = contact.Id,
                Phone = contact.Phone,
                Web = contact.Web,
                Email = contact.Email,
                Address = (AddressEntity)contact.Address
            };

            return contct;
        }

        public static implicit operator Contact(ContactEntity contactEntity)
        {
            if (contactEntity == null) return null;

            var contct = new Contact
            {
                Id = contactEntity.Id,
                Phone = contactEntity.Phone,
                Web = contactEntity.Web,
                Email = contactEntity.Email,
                Address = (Address)contactEntity.Address
            };

            return contct;
        }
    }
}
