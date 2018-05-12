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
        private readonly RecycleContext _dbContext;

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

        public IRecyclePoint ModifyRecyclePoint(IRecyclePoint point)
        {
            var oldPoint = _dbContext.RecyclePoints.Find(point.Id);
            if (oldPoint != null)
            {
                oldPoint = (RecyclePoint)point;

                _dbContext.SaveChanges();

                return (RecyclePoint)oldPoint;
            }
            return null;
        }

        public ICompany ModifyCompany(ICompany company)
        {
            var oldCompany = _dbContext.Companies.Find(company.Id);
            if (oldCompany != null)
            {
                oldCompany = (CompanyEntity)company;

                _dbContext.SaveChanges();

                return (Company)oldCompany;
            }

            return null;
        }

        public async Task<IRecyclePoint> AddRecyclePointAsync(IRecyclePoint point)
        {
            if (point.Id == 0)
            {
                var castPoint = point as RecyclePoint;

                var pointEntity = _dbContext.RecyclePoints.Add(castPoint);

                int result = await _dbContext.SaveChangesAsync();

                if (result > 0)
                {
                    var tmp = await _dbContext
                        .RecyclePoints
                        .Include(item => item.Company)
                        .ThenInclude(item => item.Contact)
                        .ThenInclude(item => item.Address)
                        .Include(item => item.Location)
                        .Include(item => item.Rels)
                        .ThenInclude(item => item.Category)
                        .FirstOrDefaultAsync(item => item.Id == pointEntity.Entity.Id);

                    return (RecyclePoint)tmp;
                }
            }

            return null;
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
                .Select(company => (Company)company)
                .ToListAsync();

            var result = companies
                .Select(company => (Company)company);

            return result;
        }

        public async Task<IEnumerable<Company>> GetCompaniesAsync(string userId)
        {
            var companies = await _dbContext
                .Companies
                .Include(contact => contact.Contact)
                .ThenInclude(address => address.Address)
                .Where(company => company.UserId.Equals(userId, System.StringComparison.CurrentCultureIgnoreCase))
                .ToListAsync();

            var result = companies
                .Select(company => (Company)company);

            return result;
        }

        public async Task<Company> GetCompanyAsync(int id)
        {
            return await _dbContext
                .Companies
                .Include(p => p.Contact)
                .Include(p => p.Contact.Address)
                .FirstOrDefaultAsync(item => item.Id == id);
        }

        public async Task<RecyclePoint> GetRecyclePointAsync(int id)
        {
            var r = _dbContext
                .RecyclePoints
                .Include(point => point.Location)
                .Include(point => point.Rels)
                .ThenInclude(rel => rel.Category)
                .Include(point => point.Company)
                .ThenInclude(company => company.Contact)
                .ThenInclude(contact => contact.Address)
                .FirstOrDefaultAsync(item => item.Id == id);
            return await r;
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
                .ThenInclude(address => address.Address)
                .ToListAsync()
                .ConfigureAwait(false);

            var p = res.Select(point => (RecyclePoint)point);

            return p;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _dbContext
                .Categories
                .Select(category => (Category)category)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<ICategory> AddCategoryAsync(ICategory category)
        {
            if (category == null) return null;

            if (category.Id == 0)
            {
                var tmpCat = category as Category;
                var tmp = await _dbContext.Categories.AddAsync(tmpCat);
                int i = await _dbContext.SaveChangesAsync();
                if (i > 0)
                {
                    return (Category)tmp.Entity;
                }
            }

            return null;
        }
    }
}
