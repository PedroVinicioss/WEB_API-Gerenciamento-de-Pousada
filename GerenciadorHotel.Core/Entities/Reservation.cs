namespace GerenciadorHotel.Core.Entities;

public class Reservation : BaseEntity
{
    protected Reservation() { }
    
    public Reservation(DateTime startDate, DateTime endDate, int idRoom, int idUser, int idCalendary,
        decimal totalCost = 0, int idCash = 0)
        : base()
    {
        StartDate = startDate;
        EndDate = endDate;
        TotalCost = totalCost;
        IdRoom = idRoom;
        IdCustomer = idUser;
        IdCash = idCash;
        IdCalendary = idCalendary;
        Consumptions = [];
    }

    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public decimal TotalCost { get; private set; }
    public int IdRoom { get; private set; }
    public Room Room { get; private set; }
    public int IdCustomer { get; private set; }
    public User Customer { get; private set; }
    public int IdCash { get; private set; }
    public Cash Cash { get; private set; }
    public Calendary Calendary { get; private set; }
    public int IdCalendary { get; private set; }
    public List<Consumption> Consumptions { get; private set; }

    
    public void Update(Reservation reservation)
    {
        StartDate = reservation.StartDate;
        EndDate = reservation.EndDate;
        IdRoom = reservation.IdRoom;
        IdCustomer = reservation.IdCustomer;
        IdCalendary = reservation.IdCalendary;
    }
    
    public void AddConsumption(Consumption consumption)
    {
        Consumptions.Add(consumption);
    }
    
    public void RemoveConsumption(Consumption consumption)
    {
        Consumptions.Remove(consumption);
    }
    
    public void CalculateTotalCost()
    {
        TotalCost = Consumptions.Sum(c => c.Value);
    }
    
    public void SetCash(int idCash)
    {
        IdCash = idCash;
    }
}