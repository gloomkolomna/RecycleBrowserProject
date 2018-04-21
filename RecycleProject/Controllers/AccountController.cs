using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using RecycleProject.Enums.Autenticate;
using System.Security.Claims;
using RecycleProject.Interfaces.Authenticate.Jwt;
using Newtonsoft.Json;

namespace RecycleProject.Controllers
{
    [Produces("application/json")]
    [Route("api/account")]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtFactory _jwtFactory;

        public AccountController(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IJwtFactory jwtFactory)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtFactory = jwtFactory;

            foreach (var role in Enum.GetValues(typeof(BaseRole)))
            {
                var roleExist = _roleManager.RoleExistsAsync(role.ToString()).Result;
                if (!roleExist)
                {
                    IdentityRole newRole = new IdentityRole(role.ToString());
                    _roleManager.CreateAsync(newRole).Wait();
                }
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [Route("add_role")]
        public JsonResult AddRole()
        {
            return Json(Ok());
        }

        [Authorize(Roles = "Administrator")]
        [AllowAnonymous]
        [HttpPost]
        [Route("add_user")]
        public async Task<JsonResult> AddUserAsync()
        {
            return Json(Ok());
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("signin")]
        public async Task<JsonResult> SignInAsync()
        {
            return Json(Ok());
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("signup")]
        public async Task<JsonResult> SignUpAsync()
        {
            return Json(Ok());
        }

        [Authorize]
        [HttpPost]
        [Route("signout")]
        public JsonResult SignOut()
        {
            return Json(Ok());
        }
    }
}