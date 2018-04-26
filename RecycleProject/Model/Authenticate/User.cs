using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace RecycleProject.Interfaces.Authenticate
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public IEnumerable<string> Roles { get; set; }

        public static implicit operator IdentityUser(User user)
        {
            return new IdentityUser
            {
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName
            };
        }
    }
}