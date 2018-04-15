using RecycleProject.Interfaces.Models;
using RecycleProject.Interfaces.Models.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecycleProject.Model.Entity
{
    [Table("category")]
    internal class CategoryEntity : ICategoryEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<PointCategoryRelationship> Rels { get; set; }

        public static implicit operator CategoryEntity(Category category)
        {
            if (category == null) return null;

            var cat = new CategoryEntity
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                Rels = new HashSet<PointCategoryRelationship>()
            };

            return cat;
        }

        public static implicit operator Category(CategoryEntity categoryEntity)
        {
            if (categoryEntity == null) return null;

            var cat = new Category
            {
                Id = categoryEntity.Id,
                Name = categoryEntity.Name,
                Description = categoryEntity.Description
            };

            return cat;
        }
    }
}
