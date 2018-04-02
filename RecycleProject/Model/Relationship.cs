using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecycleProject.Model
{
    public class Relationship
    {
        public int Id { get; set; }
        public int RecyclePointId { get; set; }
        public virtual RecyclePoint RecyclePoint { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
