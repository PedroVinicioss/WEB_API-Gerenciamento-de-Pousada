using GerenciadorHotel.Core.Entities;

namespace GerenciadorHotel.Application.Models.InputModels;

public class CreateConsumptionInputModel
{
    public int IdProduct { get; set; }
    public int IdReservation { get; set; }
    public int Quantity { get; set; }
    public DateTime Date { get; set; }
    public string? Observation { get; set; }
    public Product Product { get; set; }

    public Consumption ToEntity()
    {
        decimal value = 0;
        value = Quantity * Product.Price;
        return new Consumption(IdProduct, IdReservation, Quantity, value, Date);
    }
}