using RecycleProject.Model;
using System;
using System.Collections.Generic;

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
