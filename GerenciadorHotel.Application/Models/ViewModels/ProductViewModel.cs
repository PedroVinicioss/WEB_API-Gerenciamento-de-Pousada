using GerenciadorHotel.Core.Entities;

namespace GerenciadorHotel.Application.Models.ViewModels;

public class ProductViewModel
{
    public ProductViewModel(int id, string name, string description, decimal price, string type, int stock, List<Consumption> consumptions)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        Type = type;
        Stock = stock;
        IsAvailable = stock > 0;
        Consumptions = consumptions?.Select(ConsumptionViewModel.FromEntity).ToList() ?? new List<ConsumptionViewModel>();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Type { get; set; }
    public int Stock { get; set; }
    public bool IsAvailable { get; set; }
    public List<ConsumptionViewModel> Consumptions { get; set; }
    
    public static ProductViewModel FromEntity(Product entity)
        => new(entity.Id, entity.Name, entity.Description, entity.Price, entity.Category.ToString(), entity.Stock, entity.Consumptions);
}