using RecycleProject.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecycleProject.Interfaces
{
    public interface IRepository: IDisposable
    {
        IEnumerable<IRecyclePoint> GetRecyclePoints();
        IRecyclePoint GetRecyclePoint(int id);
        IEnumerable<ICompany> GetCompanies();
        ICompany GetCompany(int id);
        void AddRecyclePoint(IRecyclePoint point);
        void AddCompany(ICompany company);
    }
}
