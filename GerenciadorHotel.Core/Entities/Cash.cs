namespace GerenciadorHotel.Core.Entities;

public class Cash : BaseEntity
{
    protected Cash() { }
    
    public Cash(DateTime openingDate, DateTime closingDate, decimal totalRevenue, decimal totalExpenses, decimal totalCash, int idAdmin)
        : base()
    {
        OpeningDate = openingDate;
        ClosingDate = closingDate;
        TotalRevenue = totalRevenue;
        TotalExpenses = totalExpenses;
        TotalCash = totalCash;
        IdAdmin = idAdmin;
        Reservations = [];
    }
    
    public DateTime OpeningDate { get; private set; }
    public DateTime ClosingDate { get; private set; }
    public decimal TotalRevenue { get; private set; }
    public decimal TotalExpenses { get; private set; }
    public decimal TotalCash { get; private set; }
    public int IdAdmin { get; private set; }
    public User Admin { get; private set; }
    public List<Reservation> Reservations { get; private set; }
    
    public void Update(DateTime openingDate, DateTime closingDate, decimal totalRevenue, decimal totalExpenses, decimal totalCash, int idAdmin, Reservation reservation)
    {
        OpeningDate = openingDate;
        ClosingDate = closingDate;
        TotalRevenue = totalRevenue;
        TotalExpenses = totalExpenses;
        TotalCash = totalCash;
        IdAdmin = idAdmin;
        Reservations.Add(reservation);
    }
}