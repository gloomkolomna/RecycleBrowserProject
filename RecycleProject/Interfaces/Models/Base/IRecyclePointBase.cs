﻿using RecycleProject.Enums.Model;

namespace RecycleProject.Interfaces.Models.Base
{
    public interface IRecyclePointBase
    {
        int Id { get; set; }
        Days WorkDays { get; set; }
    }
}
