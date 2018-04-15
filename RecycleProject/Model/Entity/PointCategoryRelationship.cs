using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RecycleProject.Model.Entity
{
    [Table("relationship")]
    internal class PointCategoryRelationship
    {
        public int Id { get; set; }
        public int RecyclePointId { get; set; }
        public RecyclePointEntity RecyclePoint { get; set; }
        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
    }
}
