using IWantApp.Domain.Products;
using IWantApp.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace IWantApp.Endpoints.Categories;

public class CategoryPut
{
    public static string Template => "/categories/{id}";
    public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] int id, CategoryRequest categoryRequest, ApplicationDbContext context)
    {
        var category = context.Categories.Where(c => c.Id == id).FirstOrDefault();

        category.Name = categoryRequest.Name;
        category.Active = categoryRequest.Active;
        category.EditedBy = "Dadalto";
        category.EditedOn = DateTime.Now;
        
        context.SaveChanges();

        return Results.Ok(category);
    }
}
