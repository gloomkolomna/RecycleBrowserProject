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
        public async Task<JsonResult> GetPoint(int id)
        {
            return await Task.Run(() =>
            {
                RecyclePoint currentPoint = _repo.GetRecyclePoint(id);
                return Json(currentPoint);
            });
        }
    }
}