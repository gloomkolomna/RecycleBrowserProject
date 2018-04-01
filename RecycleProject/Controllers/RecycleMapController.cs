using Microsoft.AspNetCore.Mvc;
using RecycleProject.Enums;
using RecycleProject.Interfaces;
using RecycleProject.Interfaces.Models;
using RecycleProject.Model;
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
        [Route("get_recyclepoint")]
        public async Task<JsonResult> GetPoint(int id)
        {
            return await Task.Run(() =>
            {
                var d = (Days)31;
                RecyclePoint currentPoint = _repo.GetRecyclePoint(id);
                return Json(currentPoint);
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