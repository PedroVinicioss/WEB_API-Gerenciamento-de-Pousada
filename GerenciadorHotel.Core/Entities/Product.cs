using GerenciadorHotel.Core.Enums;

namespace GerenciadorHotel.Core.Entities;

public class Product : BaseEntity
{
    protected Product() { }
    
    public Product(string name, string description, decimal price, ProductCategoryEnum category, int stock)
        : base()
    {
        Name = name;
        Description = description;
        Price = price;
        IsAvailable = true;
        Category = category;
        Consumptions = [];
        Stock = stock;
    }
    
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public bool IsAvailable { get; private set; }
    public int Stock { get; set; }
    public ProductCategoryEnum Category { get; private set; }
    public List<Consumption> Consumptions { get; private set; }
    
    public void Update(string name, string description, decimal price, bool isAvailable, ProductCategoryEnum category, Consumption consumption, int stock)
    {
        Name = name;
        Description = description;
        Price = price;
        IsAvailable = isAvailable;
        Category = category;
        Consumptions.Add(consumption);
        Stock = stock;
    }
    
    public void SetAsAvailable()
    {
        IsAvailable = true;
    }
    
    public void SetAsUnavailable()
    {
        IsAvailable = false;
    }
    
    public void AddStock(int quantity)
    {
        if(Stock == 0)
        {
            SetAsAvailable();
        }
        Stock += quantity;
    }
    
    public void RemoveStock(int quantity)
    {
        if(Stock - quantity == 0)
        {
            SetAsUnavailable();
        }
        Stock -= quantity;
    }
}