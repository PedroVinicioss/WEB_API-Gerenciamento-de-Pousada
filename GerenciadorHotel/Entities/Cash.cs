namespace GerenciadorHotel.Entities;

public class Cash : BaseEntity
{
    public DateTime OpeningDate { get; private set; }
    public DateTime ClosingDate { get; private set; }
    public decimal TotalRevenue { get; private set; }
    public decimal TotalExpenses { get; private set; }
    public decimal TotalCash { get; private set; }
}