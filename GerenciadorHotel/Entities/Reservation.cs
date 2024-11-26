namespace GerenciadorHotel.Entities;

public class Reservation : BaseEntity
{
    protected Reservation() { }
    
    public Reservation(DateTime startDate, DateTime endDate, decimal totalCost, int idRoom, int idUser, int idCash, int idCalendary)
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

    
    public void Update(DateTime startDate, DateTime endDate, decimal totalCost, int idCalendary, Consumption consumption)
    {
        StartDate = startDate;
        EndDate = endDate;
        TotalCost = totalCost;
        IdCalendary = idCalendary;
        Consumptions.Add(consumption);
    }
}