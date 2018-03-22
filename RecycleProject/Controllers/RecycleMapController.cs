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
        public JsonResult GetPoint(int id)
        {
            RecyclePoint currentPoint = null;
            using (var repo = new Repository())
            {
                currentPoint = repo.GetRecyclePoint(id);
            }
                /*ICompany company = new Company()
                {
                    Name = "Рога и копыта",
                    Description = "Просто описание компании",
                    Contact = new Contact
                    {
                        Email = "aaa@aa.aa",
                        Web = "aa.aa",
                        Phone = "+7 987 654 32 10",
                        Adress = new Adress()
                        {
                            Index = 140408,
                            City = "Коломна",
                            Street = "Центральная",
                            Home = "8 Б"
                        }
                    },
                    RecycleTypes = new[]
                    {
                        new RecycleType
                        {
                             Name= "Plastic"
                        },
                         new RecycleType
                        {
                             Name= "Batteries"
                        },
                         new RecycleType
                        {
                             Name= "Bulbs"
                        }
                    }
                };*/

                /*IRecyclePoint point = new RecyclePoint()
                {
                    Location = new Location
                    {
                        Latitude = 0d,
                        Longitude = 1d
                    },
                    Types = new[]
                    {
                    new RecycleType
                    {
                         Name= "Plastic"
                    },
                     new RecycleType
                    {
                         Name= "Batteries"
                    }
                },
                    Company = company,
                    WorkDays = new[] { Days.Monday, Days.Tuesday },
                };*/

            //company.RecyclePoints = new[] { point };

            return Json(currentPoint);
        }
    }
}