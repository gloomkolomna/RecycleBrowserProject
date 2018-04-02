using RecycleProject.Model;
using System;
using System.Collections.Generic;

namespace RecycleProject.Interfaces
{
    public interface IRepository: IDisposable
    {
        IEnumerable<Point> GetRecyclePoints();
        Point GetRecyclePoint(int id);
        Point GetRecyclePoint(double lon, double lat);
        IEnumerable<Company> GetCompanies();
        Company GetCompany(int id);
        void AddRecyclePoint(Point point);
        void AddCompany(Company company);
        Point ModifityRecyclePoint(Point point);
        Company ModifityCompany(Company company);
    }
}
