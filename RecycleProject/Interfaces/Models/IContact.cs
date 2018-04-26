using RecycleProject.Interfaces.Models.Base;

namespace RecycleProject.Interfaces.Models
{
    public interface IContact: IContactBase
    {
        IAddress Address { get; set; }
    }
}
