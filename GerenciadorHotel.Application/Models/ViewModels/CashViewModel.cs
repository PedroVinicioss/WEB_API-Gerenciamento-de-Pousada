using GerenciadorHotel.Core.Entities;

namespace GerenciadorHotel.Application.Models.ViewModels;

public class CashViewModel
{
    public CashViewModel(int id, DateTime openingDate, DateTime closingDate, decimal totalRevenue, decimal totalExpenses, decimal totalCash, List<Reservation> reservations)
    {
        Id = id;
        OpeningDate = openingDate;
        ClosingDate = closingDate;
        TotalRevenue = totalRevenue;
        TotalExpenses = totalExpenses;
        TotalCash = totalCash;
        Reservations = reservations?.Select(ReservationViewModel.FromEntity).ToList() ?? new List<ReservationViewModel>();
    }
    
    public int Id { get;  set; }
    public DateTime OpeningDate { get;  set; }
    public DateTime ClosingDate { get;  set; }
    public decimal TotalRevenue { get;  set; }
    public decimal TotalExpenses { get;  set; }
    public decimal TotalCash { get;  set; }
    public List<ReservationViewModel> Reservations { get;  set; }
    
    public static CashViewModel FromEntity(Cash entity)
        => new(entity.Id, entity.OpeningDate, entity.ClosingDate, entity.TotalRevenue, entity.TotalExpenses, entity.TotalCash, entity.Reservations);
}