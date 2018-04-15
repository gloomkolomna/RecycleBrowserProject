using Microsoft.EntityFrameworkCore;
using RecycleProject.Interfaces;
using RecycleProject.Interfaces.Models;
using RecycleProject.Model;
using RecycleProject.Model.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecycleProject
{
    internal class Repository : IRepository
    {
        private RecycleContext _dbContext;

        public Repository(RecycleContext dbContext)
        {
            _dbContext = dbContext;
            //dbContext.Database.EnsureCreated();
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
            var oldPoint = _dbContext.RecyclePoints.Find(point);
            if (oldPoint != null)
            {
                _dbContext.RecyclePoints.Remove(point);
                _dbContext.RecyclePoints.Add(point);

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
            //_dbContext.Dispose();
            //_dbContext = null;
        }

        public async Task<IEnumerable<Company>> GetCompaniesAsync()
        {
            var companies = await _dbContext
                .Companies
                .Include(contact => contact.Contact)
                .ThenInclude(address => address.Address)
                .ToListAsync();

            var result = companies
                .Select(company => (Company)company);

            return result;
        }

        public Company GetCompany(int id)
        {
            return _dbContext
                .Companies
                .Include(p => p.Contact)
                .Include(p => p.Contact.Address)
                .FirstOrDefault(item => item.Id == id);
        }

        public RecyclePoint GetRecyclePoint(int id)
        {
            var r = _dbContext
                .RecyclePoints
                .Include(point => point.Location)
                .Include(point => point.Rels)
                .ThenInclude(rel => rel.Category)
                .Include(point => point.Company)
                .ThenInclude(company => company.Contact)
                .ThenInclude(contact => contact.Address)
                .FirstOrDefault(item => item.Id == id);
            return r;
        }

        public async Task<IEnumerable<RecyclePoint>> GetRecyclePointsAsync()
        {
            var res = await _dbContext
                .RecyclePoints
                .Include(r => r.Rels)
                .ThenInclude(c => c.Category)
                .Include(loc => loc.Location)
                .Include(company => company.Company)
                .ThenInclude(contact => contact.Contact)
                .ThenInclude(address => address.Address).ToListAsync();

            var p = res.Select(point => (RecyclePoint)point);

            return p;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _dbContext.Categories.Select(category => (Category)category).ToListAsync();
        }

        public Category AddCategory(Category category)
        {
            if (category == null) return null;

            if (category.Id == 0)
            {
                var tmp = _dbContext.Categories.Add(category);
                int i = _dbContext.SaveChanges();
                if (i > 0)
                {
                    category = tmp.Entity;
                }
            }

            return category;
        }
    }
}
