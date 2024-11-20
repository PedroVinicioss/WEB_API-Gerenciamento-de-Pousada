using GerenciadorHotel.Enums;

namespace GerenciadorHotel.Entities;

public class Product : BaseEntity
{
    protected Product() { }
    
    public Product(string name, string description, decimal price, ProductCategoryEnum category)
        : base()
    {
        Name = name;
        Description = description;
        Price = price;
        IsAvailable = true;
        Category = category;
    }
    
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public bool IsAvailable { get; private set; }
    public ProductCategoryEnum Category { get; private set; }
    
    public void Update(string name, string description, decimal price, bool isAvailable, ProductCategoryEnum category)
    {
        Name = name;
        Description = description;
        Price = price;
        IsAvailable = isAvailable;
        Category = category;
    }
    
    public void SetAsAvailable()
    {
        IsAvailable = true;
    }
    
    public void SetAsUnavailable()
    {
        IsAvailable = false;
    }
}