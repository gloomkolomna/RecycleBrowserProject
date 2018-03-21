using Microsoft.AspNetCore.Mvc;
using RecycleProject.Model;
using RecycleProject.Model.Enums;
using RecycleProject.Model.Interfaces;

namespace RecycleProject.Controllers
{
    [Produces("application/json")]
    [Route("api/RecycleMap")]
    public class RecycleMapController : Controller
    {
        [HttpGet]
        public JsonResult GetPoint()
        {
            ICompany company = new Company()
            {
                Name = "Рога и копыта",
                Description = "Просто описание компании",
                Email = "aaa@aa.aa",
                Web = "aa.aa",
                Phone = "+7 987 654 32 10",
                CompanyGraphicses = new[] { CompanyGraphics.Monday, CompanyGraphics.Tuesday },
                RecycleTypes = new[] { RecycleType.Appliances, RecycleType.Batteries, RecycleType.Bulbs },
            };

            IRecyclePoint point = new RecyclePoint()
            {
                Name = "First",
                Description = "First Point in first Core application.",
                Location = new Location
                {
                    Latitude = 0d,
                    Longitude = 1d
                },
                Types = new[] { RecycleType.Appliances, RecycleType.Batteries, RecycleType.Bulbs },
                Company = company
            };

            company.RecyclePoints = new[] { point };

            return Json(point);
        }
    }
}