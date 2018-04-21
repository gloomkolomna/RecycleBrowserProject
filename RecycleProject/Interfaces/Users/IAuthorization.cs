using RecycleProject.Enums.Autenticate;

namespace RecycleProject.Interfaces.Model
{
    public interface IAuthorization
    {
        string Token { get; set; }
        string UserId { get; set; }
        //BaseRole AuthorizationType { get; set; }
    }
}
