using GerenciadorHotel.Core.Entities;

namespace GerenciadorHotel.Application.Models.ViewModels;

public class ConsumptionViewModel
{
    public ConsumptionViewModel(int id, int quantity, decimal totalValue, string productName, int idProduct, Reservation reservation, DateTime consumptionDate)
    {
        Id = id;
        Quantity = quantity;
        Value = totalValue;
        ProductName = productName;
        IdProduct = idProduct;
        CustomerName = reservation.Customer.FullName;
        ConsumptionDate = consumptionDate;
    }

    public int Id { get; set; }
    public int Quantity { get; set; }
    public decimal Value { get; set; }
    public string ProductName { get; set; }
    public int IdProduct { get; set; }
    public string CustomerName { get; set; }
    public DateTime ConsumptionDate { get; private set; }
    
    public static ConsumptionViewModel FromEntity(Consumption entity)
        => new(entity.Id, entity.Quantity, entity.Value, entity.Product.Name, entity.IdProduct, entity.Reservation, entity.ConsumptionDate);
}