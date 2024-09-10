
namespace Efcore.Entities;

public sealed class CustomerEntity : BaseEntity
{
    public string ZipCode { get; set; }
    public string City { get; set; }
    public string State { get; set; }

    public IEnumerable<OrderEntity>? Orders { get; set; }

    public CustomerEntity(string zipCode, string city, string state)
    {
        var validation = new ValidationDomain();
        validation.when(string.IsNullOrEmpty(zipCode), "O cep é obrigatório.");
        validation.when(zipCode.Length != 8, "O cep deve conter 8 caracteres.");
        validation.when(string.IsNullOrEmpty(city), "A cidade é obrigatória.");
        validation.when(string.IsNullOrEmpty(state), "O estado é obrigatório.");
        validation.when(state.Length != 2, "A sigla do estado deve conter 2 caracteres.");
        validation.Execute();

        this.ZipCode = zipCode;
        this.City = city;
        this.State = state;
    }
}
