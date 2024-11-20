namespace GerenciadorHotel.Entities;

public class Reservation : BaseEntity
{
    protected Reservation() { }
    
    public Reservation(DateTime startDate, DateTime endDate, decimal totalCost, int idRoom, int idUser)
        : base()
    {
        StartDate = startDate;
        EndDate = endDate;
        TotalCost = totalCost;
        IdRoom = idRoom;
        IdCustomer = idUser;
    }

    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public decimal TotalCost { get; private set; }
    public int IdRoom { get; private set; }
    public Room Room { get; private set; }
    public int IdCustomer { get; private set; }
    public User Customer { get; private set; }
    
    
    public void Update(DateTime startDate, DateTime endDate, decimal totalCost)
    {
        StartDate = startDate;
        EndDate = endDate;
        TotalCost = totalCost;
    }
}