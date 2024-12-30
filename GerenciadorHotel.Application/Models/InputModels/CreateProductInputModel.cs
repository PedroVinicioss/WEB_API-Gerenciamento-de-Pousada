using GerenciadorHotel.Core.Entities;
using GerenciadorHotel.Core.Enums;

namespace GerenciadorHotel.Application.Models.InputModels;

public class CreateProductInputModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public ProductCategoryEnum Category { get; set; }
    public int Stock { get; set; }
    
    public Product ToEntity()
        => new Product(Name, Description, Price, Category, Stock);
}