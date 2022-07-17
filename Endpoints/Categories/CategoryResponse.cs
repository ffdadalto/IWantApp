namespace IWantApp.Endpoints.Categories;

public class CategoryResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Active { get; set; }

    public CategoryResponse(int id, string name, bool active)
    {
        Id = id;
        Name = name;
        Active = active;
    }

}