using RecycleProject.Enums;
using RecycleProject.Interfaces.Models;
using RecycleProject.Interfaces.Models.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace RecycleProject.Model.Entity
{
    [Table("recyclepoint")]
    internal class RecyclePointEntity: IRecyclePointEntity
    {
        [Key]
        public int Id { get; set; }
        public LocationEntity Location { get; set; }
        public IEnumerable<PointCategoryRelationship> Rels { get; set; }
        public Days WorkDays { get; set; }
        public CompanyEntity Company { get; set; }

        public static implicit operator RecyclePointEntity(RecyclePoint point)
        {
            if (point == null) return null;

            var pnt = new RecyclePointEntity
            {
                Id = point.Id,
                Location = (LocationEntity)point.Location,
                WorkDays = point.WorkDays,
                Company = (CompanyEntity)point.Company,
                Rels = MappingCategory(point.Categories, point)
            };

            return pnt;
        }

        public static implicit operator RecyclePoint(RecyclePointEntity pointEntity)
        {
            if (pointEntity == null) return null;

            var pnt = new RecyclePoint
            {
                Id = pointEntity.Id,
                Location = (Location)pointEntity.Location,
                WorkDays = pointEntity.WorkDays,
                Company = (Company)pointEntity.Company,
                Categories = pointEntity.Rels.Select(cat => (Category)cat.Category)
            };

            return pnt;
        }

        private static IEnumerable<PointCategoryRelationship> MappingCategory(IEnumerable<ICategory> categories, RecyclePoint point)
        {
            var relList = new List<PointCategoryRelationship>();

            if (categories == null || !categories.Any()) return relList;

            categories.AsParallel().ForAll(category =>
            {
                relList.Add(new PointCategoryRelationship
                {
                    RecyclePoint = point,
                    RecyclePointId = point.Id,
                    Category = (CategoryEntity)category,
                    CategoryId = category.Id
                });
            });

            return relList;
        }
    }
}
