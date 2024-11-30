namespace GerenciadorHotel.Core.Entities;

public class Calendary : BaseEntity
{
    protected Calendary() { }
    
    public Calendary(int idRoom, DateTime date, bool isAvailable, int? idReservation) : base()
    {
        IdRoom = idRoom;
        Date = date;
        IsAvailable = true;
        IdReservation = idReservation;
    }
    
    public int IdRoom { get; private set; }
    public Room Room { get; private set; }
    public DateTime Date { get; private set; }
    public bool IsAvailable { get; private set; }
    public int? IdReservation { get; private set; }
    public Reservation Reservation { get; private set; }
    
    public void Update(int idRoom, DateTime date, bool isAvailable, int? idReservation)
    {
        IdRoom = idRoom;
        Date = date;
        IsAvailable = isAvailable;
        IdReservation = idReservation;
    }
}