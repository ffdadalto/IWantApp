using IWantApp.Domain.Products;
using IWantApp.Infra.Data;

namespace IWantApp.Endpoints.Categories;

public class CategoryPost
{
    public static string Template => "/category";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(CategoryRequest categoryRequest, ApplicationDbContext context)
    {
        var category = new Category
        {
            Name = categoryRequest.Name,
            CreatedBy = "UsuarioTeste",
            CreatedOn = DateTime.Now,
            EditedBy = "UsuarioTeste",
            EditedOn = DateTime.Now
        };
        context.Categories.Add(category);
        context.SaveChanges();

        var response = new CategoryResponse
        {
            Id = category.Id,
            Name = category.Name,
            Active = category.Active
        };

        return Results.Created($"/categories/{response.Id}", response);
    }
}
