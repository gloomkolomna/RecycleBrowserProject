namespace RecycleProject.Interfaces.Models.Base
{
    public interface IContactBase
    {
        int Id { get; set; }
        string Phone { get; set; }
        string Web { get; set; }
        string Email { get; set; }
    }
}
