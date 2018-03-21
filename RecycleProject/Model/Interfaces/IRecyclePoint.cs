namespace RecycleProject.Model.Interfaces
{
    public interface IRecyclePoint
    {
        string Name { get; set; }
        ILocation Location { get; set; }
        string Description { get; set; }
    }
}