using Microsoft.AspNetCore.Mvc;
using RecycleProject.Enums;
using RecycleProject.Interfaces;
using RecycleProject.Interfaces.Models;
using RecycleProject.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecycleProject.Controllers
{
    [Produces("application/json")]
    [Route("api/recycle_map")]
    public class RecycleMapController : Controller
    {
        private IRepository _repo;
        public RecycleMapController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route("recyclepoint")]
        [Route("recyclepoint/{id}")]
        public async Task<JsonResult> GetPoint(int id)
        {
            return await Task.Run(() =>
            {
                RecyclePoint currentPoint = _repo.GetRecyclePoint(id);
                return Json(currentPoint);
            });
        }

        [HttpGet]
        [Route("recyclepoints")]
        public async Task<JsonResult> GetPoints()
        {
            IEnumerable<RecyclePoint> points = await _repo.GetRecyclePointsAsync();
            return Json(points);
        }

        [HttpGet]
        [Route("categories")]
        public async Task<JsonResult> GetCategories()
        {
            IEnumerable<Category> categories = await _repo.GetCategoriesAsync();
            return Json(categories);
        }

        [HttpGet]
        [Route("company")]
        [Route("company/{id}")]
        public async Task<JsonResult> GetCompany(int id)
        {
            return await Task.Run(() =>
            {
                Company currentCompany = _repo.GetCompany(id);
                return Json(currentCompany);
            });
        }

        [HttpGet]
        [Route("companies")]
        public async Task<JsonResult> GetCompanies()
        {
            IEnumerable<Company> currentCompany = await _repo.GetCompaniesAsync();
            return Json(currentCompany);
        }

        [HttpPost]
        [Route("add_category")]
        public JsonResult AddCategory([FromBody] Category category)
        {
            category = _repo.AddCategory(category);

            return Json(Ok(category));
        }
    }
}