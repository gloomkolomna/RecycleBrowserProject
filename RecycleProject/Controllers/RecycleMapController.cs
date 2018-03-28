using System;
using Microsoft.AspNetCore.Mvc;
using RecycleProject.Interfaces;
using RecycleProject.Model;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RecycleProject.Controllers
{
    [Produces("application/json")]
    [Route("api/RecycleMap")]
    public class RecycleMapController : Controller
    {
        private IRepository _repo;
        public RecycleMapController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route("get_recyclepoint_id")]
        public async Task<JsonResult> GetPoint(int id)
        {
            return await Task.Run(() =>
            {
                RecyclePoint currentPoint = _repo.GetRecyclePoint(id);
                return Json(currentPoint);
            });
        }

        [Route("get_recyclepoint_location")]
        public async Task<JsonResult> GetPoint(double lon, double lat)
        {
            return await Task.Run(() =>
            {
                RecyclePoint currentPoint = _repo.GetRecyclePoint(lon, lat);
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

        [HttpGet]
        [Route("get_companies")]
        public async Task<JsonResult> GetCompanies()
        {
            return await Task.Run(() =>
            {
                var companies = _repo.GetCompanies();
                return Json(companies);
            });
        }

        [HttpPost]
        [Route("set_point")]
        public async Task<JsonResult> SetPoint(string result)
        {
            return await Task.Run(() =>
            {
                var point = JsonConvert.DeserializeObject<RecyclePoint>(result);
                if (point == null)
                    throw new Exception("Error Recycle Point POST");

                _repo.AddRecyclePoint(point);
                return Json(point);
            });
        }

        [HttpPost]
        [Route("set_company")]
        public async Task<JsonResult> SetCompany(string result)
        {
            return await Task.Run(() =>
            {
                var company = JsonConvert.DeserializeObject<Company>(result);
                if (company == null)
                    throw new Exception("Error Recycle Company POST");

                _repo.AddCompany(company);
                return Json(company);
            });
        }
    }
}