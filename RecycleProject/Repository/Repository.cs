using Microsoft.EntityFrameworkCore;
using RecycleProject.Interfaces;
using RecycleProject.Model;
using System.Collections.Generic;
using System.Linq;

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
            if (!_dbContext.Companies.Any())
            {
                _dbContext.Companies.Add(company);
                _dbContext.SaveChanges();
            }
            else
            {
                var dbCompany = _dbContext.Companies.FirstOrDefault(item =>
                    item.Name == company.Name && item.Contact == company.Contact);

                if (dbCompany == null)
                {
                    _dbContext.Companies.Add(company);
                    _dbContext.SaveChanges();
                }
            }
        }

        public Point ModifityRecyclePoint(Point point)
        {
            var oldPoint = _dbContext.Points.Find(point);
            if (oldPoint != null)
            {
                _dbContext.Points.Remove(point);
                _dbContext.Points.Add(point);

                _dbContext.SaveChanges();

                return point;
            }

            return null;
        }

        public Company ModifityCompany(Company company)
        {
            var oldCompany = _dbContext.Companies.Find(company);
            if (oldCompany != null)
            {
                _dbContext.Companies.Remove(company);
                _dbContext.Companies.Add(company);

                _dbContext.SaveChanges();

                return company;
            }

            return null;
        }

        public void AddRecyclePoint(Point point)
        {
            if (!_dbContext.Points.Any())
            {
                _dbContext.Points.Add(point);
                _dbContext.SaveChanges();
            }
            else
            {
                var dbPoint = _dbContext.Points.FirstOrDefault(item =>
                    item.Location.Latitude == point.Location.Latitude &&
                    item.Location.Longitude == point.Location.Longitude);

                if (dbPoint == null)
                {
                    _dbContext.Points.Add(point);
                    _dbContext.SaveChanges();
                }
            }
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            _dbContext = null;
        }

        public Point GetRecyclePoint(double lon, double lat)
        {
            return _dbContext.Points
                .Include(p => p.Location)
                .Include(p => p.Categories)
                .Include(s => s.Company)
                .Include(p => p.Company.Contact)
                .Include(p => p.Company.Contact.Address)
                .FirstOrDefault(item => item.Location != null && item.Location.Latitude == lat && item.Location.Longitude == lon);
        }

        public IEnumerable<Company> GetCompanies()
        {
            return _dbContext.Companies;
        }

        public Company GetCompany(int id)
        {
            return _dbContext.Companies
                .Include(p => p.Contact)
                .Include(p => p.Contact.Address)
                .FirstOrDefault(item => item.Id == id);
        }

        public Point GetRecyclePoint(int id)
        {
            return _dbContext.Points
                .Include(p => p.Location)
                .Include(s => s.Company)
                .Include(p => p.Categories)
                .Include(p => p.Company.Contact)
                .Include(p => p.Company.Contact.Address)
                .FirstOrDefault(item => item.Id == id);
        }

        public IEnumerable<Point> GetRecyclePoints()
        {
            return _dbContext.Points
                .Include(p => p.Location)
                .Include(p => p.Categories)
                .Include(s => s.Company)
                .Include(p => p.Company.Contact)
                .Include(p => p.Company.Contact.Address);
        }
    }
}
