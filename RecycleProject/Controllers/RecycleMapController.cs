using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecycleProject.Model;
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
            IRecyclePoint point = new RecyclePoint()
            {
                Name = "First",
                Description = "First Point in first Core application.",
                Location = new Location
                {
                    Latitude = 0d,
                    Longitude = 1d
                }
            };

            return Json(point);
        }
    }
}