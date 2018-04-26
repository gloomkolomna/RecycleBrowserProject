using Newtonsoft.Json;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RecycleProject.Interfaces.Authenticate.Jwt
{
    public interface IJwtFactory
    {
        Task<string> GenerateEncodedToken(string userName, ClaimsIdentity identity);
        Task<string> GenerateJwt(string userName, ClaimsIdentity identity, JsonSerializerSettings serializerSettings);
        ClaimsIdentity GenerateClaimsIdentity(IEnumerable<Claim> claims);
    }
}