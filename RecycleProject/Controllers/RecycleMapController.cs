using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecycleProject.Enums.Autenticate;
using RecycleProject.Interfaces;
using RecycleProject.Model;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RecycleProject.Controllers
{
    [Produces("application/json")]
    [Route("api/recycle_map")]
    public class RecycleMapController : Controller
    {
        private readonly IRepository _repo;

        public RecycleMapController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route("recyclepoint")]
        [Route("recyclepoint/{id}")]
        public async Task<JsonResult> GetPoint(int id)
        {
            var point = await _repo.GetRecyclePointAsync(id);
            return Json(Ok(point));
        }

        [HttpGet]
        [Route("recyclepoints")]
        public async Task<JsonResult> GetPoints()
        {
            var points = await _repo.GetRecyclePointsAsync();
            return Json(Ok(points));
        }

        [HttpGet]
        [Authorize(Roles = "Administrator, Manager")]
        [Route("categories")]
        public async Task<JsonResult> GetCategories()
        {
            var categories = await _repo.GetCategoriesAsync();
            return Json(Ok(categories));
        }

        [HttpGet]
        [Route("company")]
        [Route("company/{id}")]
        public async Task<JsonResult> GetCompany(int id)
        {
            Company currentCompany = await _repo.GetCompanyAsync(id);
            return Json(Ok(currentCompany));
        }

        [HttpGet]
        [Authorize(Roles = "Administrator, Manager")]
        [Route("all_companies")]
        public async Task<JsonResult> GetCompanies()
        {
            var currentCompanies = await _repo.GetCompaniesAsync();
            return Json(Ok(currentCompanies));
        }

        [HttpGet]
        [Authorize(Roles = "Administrator, Manager")]
        [Route("user_companies/{id?}")]
        public async Task<JsonResult> GetUserCompanies(string id = null)
        {
            ClaimsPrincipal user = HttpContext.User;
            IEnumerable<Claim> userClaims = user.Claims;
            string userId = string.Empty;

            if (!string.IsNullOrEmpty(id) && user.IsInRole(BaseRole.Administrator.ToString()))
                userId = id;
            else userId = userClaims.FirstOrDefault(claim => claim.Type == "id")?.Value;

            var currentCompany = await _repo.GetCompaniesAsync(userId);
            return Json(Ok(currentCompany));
        }

        [HttpPost]
        [Authorize(Roles = "Administrator, Manager")]
        [Route("add_category")]
        public JsonResult AddCategory([FromBody] Category category)
        {
            category = _repo.AddCategory(category);

            return Json(Ok(category));
        }
    }
}