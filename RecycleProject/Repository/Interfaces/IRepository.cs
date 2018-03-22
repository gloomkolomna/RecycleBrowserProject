using RecycleProject.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecycleProject.Model;

namespace RecycleProject.Interfaces
{
    public interface IRepository: IDisposable
    {
        IEnumerable<RecyclePoint> GetRecyclePoints();
        RecyclePoint GetRecyclePoint(int id);
        IEnumerable<Company> GetCompanies();
        Company GetCompany(int id);
        void AddRecyclePoint(RecyclePoint point);
        void AddCompany(Company company);
        RecyclePoint ModifityRecyclePoint(RecyclePoint point);
        Company ModifityCompany(Company company);
    }
}
