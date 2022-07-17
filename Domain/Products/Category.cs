using Flunt.Validations;

namespace IWantApp.Domain.Products;

public class Category : Entity
{
    public bool Active { get; set; } = true;

    public Category(string name)
    {
        var contract = new Contract<Category>()
            .IsNotNullOrEmpty(name, "Name");

        AddNotifications(contract);

        Name = name;
        Active = true;
        CreatedBy = "UsuarioTeste";
        CreatedOn = DateTime.Now;
        EditedBy = "UsuarioTeste";
        EditedOn = DateTime.Now;
    }
}
