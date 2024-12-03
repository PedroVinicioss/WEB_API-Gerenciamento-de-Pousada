namespace GerenciadorHotel.Core.Entities;

public class Consumption : BaseEntity
{
    protected Consumption() { }
    
    public Consumption(int idReservation, int idProduct, int quantity, decimal value, DateTime consumptionDate)
        : base()
    {
        IdReservation = idReservation;
        IdProduct = idProduct;
        Quantity = quantity;
        Value = value;
        ConsumptionDate = DateTime.Now;
    }
    
    public int IdReservation { get; private set; }
    public Reservation Reservation { get; private set; }
    public int IdProduct { get; private set; }
    public Product Product { get; private set; }
    public int Quantity { get; private set; }
    public decimal Value { get; private set; }
    public DateTime ConsumptionDate { get; private set; }
    
    public void Update(Consumption consumption)
    {
        IdReservation = consumption.IdReservation;
        IdProduct = consumption.IdProduct;
        Quantity = consumption.Quantity;
        Value = consumption.Value;
        ConsumptionDate = consumption.ConsumptionDate;
    }
}