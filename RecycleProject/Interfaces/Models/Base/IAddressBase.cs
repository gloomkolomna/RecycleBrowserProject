namespace RecycleProject.Interfaces.Models.Base
{
    public interface IAddressBase
    {
        int Id { get; set; }
        string Street { get; set; }
        string Home { get; set; }
        string City { get; set; }
        string Region { get; set; }
        string Country { get; set; }
        string Index { get; set; }
    }
}
