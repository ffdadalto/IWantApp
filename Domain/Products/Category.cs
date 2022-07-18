using Flunt.Validations;

namespace IWantApp.Domain.Products;

public class Category : Entity
{
    public bool Active { get; set; }

    public Category(string name)
    {
        Name = name;
        Active = true;
        CreatedBy = "UsuarioTeste";
        CreatedOn = DateTime.Now;
        EditedBy = "UsuarioTeste";
        EditedOn = DateTime.Now;

        Validate();
    }

    private void Validate()
    {
        var contract = new Contract<Category>()
            .IsNotNullOrEmpty(Name, "Name")
            .IsGreaterOrEqualsThan(Name, 3, "Name");

        AddNotifications(contract);
    }

    public void EditInfo(string name, bool active)
    {
        Active = active;
        Name = name;

        Validate();
    }
}
