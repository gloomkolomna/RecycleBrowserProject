using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RecycleProject.Enums.Autenticate;
using RecycleProject.Interfaces.Authenticate;
using RecycleProject.Interfaces.Authenticate.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

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
                    _roleManager
                        .CreateAsync(new IdentityRole(role.ToString()))
                        .Wait();
                }
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [Route("add_role")]
        public async Task<JsonResult> AddRolesAsync(IEnumerable<string> roles)
        {
            if (!ModelState.IsValid)
            {
                return Json(ModelState);
            }

            var rolesExists = roles.All(role => _roleManager.RoleExistsAsync(role).Result);

            if (!rolesExists)
            {
                var taskList = roles.Select(async role =>
                {
                    return await Task.Run(async () =>
                    {
                        return await _roleManager
                                         .CreateAsync(new IdentityRole(role.ToString()));
                    });
                });

                var result = await Task.WhenAll(taskList);

                return Json(result);
            }

            return Json(Ok());
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [Route("add_user")]
        public async Task<JsonResult> AddUserAsync([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return Json(ModelState);
            }

            return await CreateUserAsync(user);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("signin")]
        public async Task<JsonResult> SignInAsync([FromBody] dynamic userInfo)
        {
            if (!ModelState.IsValid)
            {
                return Json(ModelState);
            }

            var userName = userInfo.Name.ToString();
            var userPassword = userInfo.Password.ToString();

            var identity = await GetClaimsIdentity(userName, userPassword);

            if (identity == null)
            {
                return Json(new { error = "Login failure", message = "Invalid username or password" });
            }

            var jwt = await _jwtFactory.GenerateJwt(userName, identity, new JsonSerializerSettings { Formatting = Formatting.Indented });

            return Json(Ok(jwt));
        }

        private async Task<ClaimsIdentity> GetClaimsIdentity(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                return await Task.FromResult<ClaimsIdentity>(null);

            // get the user to verifty
            var userToVerify = await _userManager.FindByNameAsync(userName);

            if (userToVerify == null) return await Task.FromResult<ClaimsIdentity>(null);

            // check the credentials
            if (await _userManager.CheckPasswordAsync(userToVerify, password))
            {
                var claims = await _userManager.GetClaimsAsync(userToVerify);
                userToVerify.AccessFailedCount = 0;
                await _userManager.UpdateAsync(userToVerify);
                return await Task.FromResult(_jwtFactory.GenerateClaimsIdentity(claims));
            }

            userToVerify.AccessFailedCount++;

            await _userManager.UpdateAsync(userToVerify);

            // Credentials are invalid, or account doesn't exist
            return await Task.FromResult<ClaimsIdentity>(null);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("signup")]
        public async Task<JsonResult> SignUpAsync([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return Json(ModelState);
            }

            user.Roles = new List<string> { BaseRole.User.ToString() };

            return await CreateUserAsync(user);
        }

        private async Task<JsonResult> CreateUserAsync(User user)
        {
            IdentityUser newUser = await _userManager.FindByNameAsync(user.UserName) ??
                await _userManager.FindByEmailAsync(user.Email);

            if (newUser != null) return Json(new { error = "Creating user with error.", message = "User already exists." });

            newUser = user;

            var rolesExists = user.Roles.All(role => _roleManager.RoleExistsAsync(role).Result);

            if (!rolesExists) return Json(new { error = "Creating user with error.", message = "Could not find the required role(s)." });

            var createUserResult = await _userManager.CreateAsync(newUser, user.Password);

            if (createUserResult.Succeeded)
            {
                var addRoleResult = await _userManager.AddToRolesAsync(newUser, user.Roles);

                if (!addRoleResult.Succeeded)
                {
                    var deleteUserResult = await _userManager.DeleteAsync(newUser);

                    return Json(new { error = "User creation failed.", message = "Could not find the required role(s)." });
                }

                var claims = new List<Claim>
                {
                    new Claim("id", newUser.Id)
                };

                user.Roles.ToList().ForEach(role => claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, role)));

                var addClaimsResult = await _userManager.AddClaimsAsync(newUser, claims);

                if (!addClaimsResult.Succeeded)
                {
                    var deleteUserResult = await _userManager.DeleteAsync(newUser);

                    return Json(new { error = "User creation failed.", message = "Could not add additional information." });
                }
            }

            return Json(createUserResult);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [Route("signout")]
        public JsonResult SignOut()
        {
            return Json(Ok());
        }
    }
}