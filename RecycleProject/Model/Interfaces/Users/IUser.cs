using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecycleProject.Model.Interfaces
{
    public interface IUser
    {
        /// <summary> Имя </summary>
        string Name { get; set; }
        /// <summary> Пол </summary>        
        bool Sex { get; set; }
        /// <summary> Способ авторизации </summary>
        IAuthorization Authorization { get; set; }
    }
}
