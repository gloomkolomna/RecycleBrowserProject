﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RecycleProject.Model.Enums;
using RecycleProject.Model.Interfaces;

namespace RecycleProject.Model
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Contact Contact { get; set; }
        public IEnumerable<RecycleType> RecycleTypes { get; set; }
        public IEnumerable<RecyclePoint> RecyclePoints { get; set; }
    }
}