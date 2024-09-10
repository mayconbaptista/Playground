
namespace Efcore.Entities;

public sealed class ProductEntity : BaseEntity
{
    public string CategoryName { get; set; }
    public uint WeightG { get; set; }
    public uint LengthCm { get; set; }
    public uint WidthCm { get; set; }
    public uint HeightCm { get; set; }

    public ProductEntity(string categoryName, uint weightG, uint lengthCm, uint widthCm, uint heightCm)
    {
        var validation = new ValidationDomain();
        validation.when(string.IsNullOrEmpty(categoryName), "O nome da categoria é obrigatório.");
        validation.when(weightG <= 0, "O peso do produto deve ser um valor válido.");
        validation.when(lengthCm <= 0, "O comprimento do produto deve ser um valor válido.");
        validation.when(widthCm <= 0, "A largura do produto deve ser um valor válido.");
        validation.when(heightCm <= 0, "A altura do produto deve ser um valor válido.");
        validation.Execute();

        CategoryName = categoryName;
        WeightG = weightG;
        LengthCm = lengthCm;
        WidthCm = widthCm;
        HeightCm = heightCm;
    }
}
