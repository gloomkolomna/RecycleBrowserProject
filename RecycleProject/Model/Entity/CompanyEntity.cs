using RecycleProject.Interfaces.Models.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecycleProject.Model.Entity
{
    [Table("company")]
    internal class CompanyEntity: ICompanyEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ContactEntity Contact { get; set; }

        public static implicit operator CompanyEntity(Company company)
        {
            if (company == null) return null;

            var cmpn = new CompanyEntity
            {
                Id = company.Id,
                Name = company.Name,
                Description = company.Description,
                Contact = (ContactEntity)company.Contact
            };

            return cmpn;
        }

        public static implicit operator Company(CompanyEntity companyEntity)
        {
            if (companyEntity == null) return null;

            var cmpn = new Company
            {
                Id = companyEntity.Id,
                Name = companyEntity.Name,
                Description = companyEntity.Description,
                Contact = (Contact)companyEntity.Contact
            };

            return cmpn;
        }
    }
}