using GerenciadorHotel.Core.Entities;

namespace GerenciadorHotel.Application.Models.InputModels;

public class UpdateReservationInputModel
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int IdRoom { get; set; }
    public int IdCustomer { get; set; }
    public int IdCalendary { get; set; }
    
    public Reservation ToEntity()
        => new(StartDate, EndDate, IdRoom, IdCustomer, IdCalendary);
}