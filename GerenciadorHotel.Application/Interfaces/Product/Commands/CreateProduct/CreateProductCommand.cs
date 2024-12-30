using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Core.Enums;
using MediatR;

namespace GerenciadorHotel.Application.Interfaces.Product.Commands.CreateProduct;

public class CreateProductCommand : IRequest<ResultViewModel<int>>
{
    public CreateProductCommand(string name, string description, decimal price, ProductCategoryEnum category, int stock)
    {
        Name = name;
        Description = description;
        Price = price;
        Category = category;
        Stock = stock;
    }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public ProductCategoryEnum Category { get; set; }
    public int Stock { get; set; }
    
    public Core.Entities.Product ToEntity()
        => new Core.Entities.Product(Name, Description, Price, Category, Stock);
}