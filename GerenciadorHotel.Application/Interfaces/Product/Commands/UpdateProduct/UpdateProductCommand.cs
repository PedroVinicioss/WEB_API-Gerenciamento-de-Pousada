using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Core.Enums;
using MediatR;

namespace GerenciadorHotel.Application.Interfaces.Product.Commands.UpdateProduct;

public class UpdateProductCommand : IRequest<ResultViewModel>
{
    public UpdateProductCommand(int id, string name, string description, decimal price, bool isAvailable, int stock, ProductCategoryEnum category)
    {
        Id = Id;
        Name = name;
        Description = description;
        Price = price;
        IsAvailable = isAvailable;
        Stock = stock;
        Category = category;
    }

    public int Id { get; set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public bool IsAvailable { get; private set; }
    public int Stock { get; set; }
    public ProductCategoryEnum Category { get; private set; }
    
    public Core.Entities.Product ToEntity()
        => new(Name, Description, Price, Category, Stock);
}