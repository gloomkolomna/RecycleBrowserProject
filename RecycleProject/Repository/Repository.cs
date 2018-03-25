using RecycleProject.Model.Interfaces;
using RecycleProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecycleProject.Model;

namespace RecycleProject
{
    public class Repository : IRepository
    {
        private RecycleContext _dbContext;

        public Repository(RecycleContext dbContext)
        {
            _dbContext = dbContext;
            dbContext.Database.EnsureCreated();
        }

        public void AddCompany(Company company)
        {
            var tmpCompany = _dbContext.RecyclePoints.Find(company);
            if (tmpCompany == null)
            {
                _dbContext.Companies.Add(company);
                _dbContext.SaveChanges();
            }
        }

        public RecyclePoint ModifityRecyclePoint(RecyclePoint point)
        {
            throw new NotImplementedException();
        }

        public Company ModifityCompany(Company company)
        {
            throw new NotImplementedException();
        }

        public void AddRecyclePoint(RecyclePoint point)
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

        }

        public IEnumerable<Company> GetCompanies()
        {
            return _dbContext.Companies;
        }

        public Company GetCompany(int id)
        {
            return _dbContext.Companies.FirstOrDefault(item => item.Id == id);
        }

        public RecyclePoint GetRecyclePoint(int id)
        {
            return _dbContext.RecyclePoints.FirstOrDefault(item => item.Id == id);
        }

        public IEnumerable<RecyclePoint> GetRecyclePoints()
        {
            return _dbContext.RecyclePoints;
        }
    }
}
