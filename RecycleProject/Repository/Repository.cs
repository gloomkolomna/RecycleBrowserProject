using RecycleProject.Model.Interfaces;
using RecycleProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecycleProject
{
    public class Repository : IRepository
    {
        RecycleContext _dbContext = new RecycleContext();

        public void AddCompany(ICompany company)
        {
            var tmpCompany = _dbContext.RecyclePoints.Find(company);
            if (tmpCompany == null)
            {
                _dbContext.Companies.Add(company);
                _dbContext.SaveChanges();
            }
        }

        public void AddRecyclePoint(IRecyclePoint point)
        {
            var tmpPoint = _dbContext.RecyclePoints.Find(point);
            if (tmpPoint == null)
            {
                _dbContext.RecyclePoints.Add(point);
                _dbContext.SaveChanges();
            }
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            _dbContext = null;
        }

        public IEnumerable<ICompany> GetCompanies()
        {
            return _dbContext.Companies;
        }

        public ICompany GetCompany(int id)
        {
            return _dbContext.Companies.FirstOrDefault(item => item.Id == id);
        }

        public IRecyclePoint GetRecyclePoint(int id)
        {
            return _dbContext.RecyclePoints.FirstOrDefault(item => item.Id == id);
        }

        public IEnumerable<IRecyclePoint> GetRecyclePoints()
        {
            return _dbContext.RecyclePoints;
        }
    }
}
