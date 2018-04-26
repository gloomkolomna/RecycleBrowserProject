using System.ComponentModel.DataAnnotations.Schema;

namespace RecycleProject.Model.Entity
{
    [Table("relationship")]
    internal class PointCategoryRelationship
    {
        public int RecyclePointId { get; set; }
        public RecyclePointEntity RecyclePoint { get; set; }
        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
    }
}
