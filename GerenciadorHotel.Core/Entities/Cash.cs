namespace GerenciadorHotel.Core.Entities;

public class Cash : BaseEntity
{
    protected Cash() { }
    
    public Cash(DateTime openingDate, DateTime closingDate, decimal totalRevenue, decimal totalExpenses, decimal totalCash, string month, int idAdmin)
        : base()
    {
        OpeningDate = openingDate;
        ClosingDate = closingDate;
        TotalRevenue = totalRevenue;
        TotalExpenses = totalExpenses;
        TotalCash = totalCash;
        Month = month;
        IdAdmin = idAdmin;
        Reservations = [];
    }
    
    public DateTime OpeningDate { get; private set; }
    public DateTime ClosingDate { get; private set; }
    public decimal TotalRevenue { get; private set; }
    public decimal TotalExpenses { get; private set; }
    public decimal TotalCash { get; private set; }
    public string Month { get; private set; }
    public int IdAdmin { get; private set; }
    public User Admin { get; private set; }
    public List<Reservation> Reservations { get; private set; }
    
    public void Update (Cash cash)
    {
        OpeningDate = cash.OpeningDate;
        ClosingDate = cash.ClosingDate;
        TotalRevenue = cash.TotalRevenue;
        TotalExpenses = cash.TotalExpenses;
        TotalCash = cash.TotalCash;
        Month = cash.Month;
        IdAdmin = cash.IdAdmin;
    }
    
    public void AddReservation(Reservation reservation)
    {
        Reservations.Add(reservation);
    }
    
    public void RemoveReservation(Reservation reservation)
    {
        Reservations.Remove(reservation);
    }
    
}