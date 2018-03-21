using RecycleProject.Model.Enums;

namespace RecycleProject.Model.Interfaces
{
    public interface IAuthorization
    {
        string Token { get; set; }
        string UserId { get; set; }
        AuthType AuthorizationType { get; set; }
    }
}
