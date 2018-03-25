using RecycleProject.Model.Enums;

namespace RecycleProject.Interfaces.Model
{
    public interface IAuthorization
    {
        string Token { get; set; }
        string UserId { get; set; }
        AuthType AuthorizationType { get; set; }
    }
}
