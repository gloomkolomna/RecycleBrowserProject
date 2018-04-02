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
        public async Task<JsonResult> GetPoint(int id)
        {
            return await Task.Run(() =>
            {
                //var d = (Days)31;
                RecyclePoint currentPoint = _repo.GetRecyclePoint(id);
                return Json(currentPoint);
            });
        }

        [HttpGet]
        [Route("recyclepoints")]
        public async Task<JsonResult> GetPoints()
        {
            return await Task.Run(() =>
            {
                IEnumerable<RecyclePoint> points = _repo.GetRecyclePoints();
                return Json(points);
            });
        }

        [HttpGet]
        [Route("categories")]
        public async Task<JsonResult> GetCategories()
        {
            return await Task.Run(() =>
            {
                IEnumerable<Category> categories = _repo.GetCategories();
                return Json(categories);
            });
        }

        [HttpGet]
        [Route("get_company")]
        public async Task<JsonResult> GetCompany(int id)
        {
            return await Task.Run(() =>
            {
                Company currentCompany = _repo.GetCompany(id);
                return Json(currentCompany);
            });
        }
    }
}