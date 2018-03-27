using Microsoft.AspNetCore.Mvc;
using RecycleProject.Interfaces;
using RecycleProject.Model;
using System.Threading.Tasks;

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
        public async Task<JsonResult> SetPoint(double lon, double lat)
        {
            return await Task.Run(() =>
            {
                var point = new RecyclePoint()
                {
                    Location = new Location()
                    {
                        Latitude = lat,
                        Longitude = lon
                    }
                };
                _repo.AddRecyclePoint(point);
                return Json(point);
            });
        }

        [HttpPost]
        [Route("set_company")]
        public async Task<JsonResult> SetCompany(string name, string description, string phone, string web, string email, 
            int index, string city, string street, string home)
        {
            return await Task.Run(() =>
            {
                var company = new Company()
                {
                    Name = name,
                    Description = description,
                    Contact = new Contact()
                    {
                        Email = email,
                        Phone = phone,
                        Web = web,
                        Address = new Address()
                        {
                            City = city,
                            Home = home,
                            Index = index,
                            Street = street
                        }
                    }
                };

                _repo.AddCompany(company);
                return Json(company);
            });
        }
    }
}