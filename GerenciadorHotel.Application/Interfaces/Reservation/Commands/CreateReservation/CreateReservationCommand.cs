using GerenciadorHotel.Application.Models;
using MediatR;

namespace GerenciadorHotel.Application.Interfaces.Reservation.Commands.CreateReservation;

public class CreateReservationCommand : IRequest<ResultViewModel<int>>
{
    public CreateReservationCommand(DateTime startDate, DateTime endDate, int idRoom, int idCustomer, int idCalendary)
    {
        StartDate = startDate;
        EndDate = endDate;
        IdRoom = idRoom;
        IdCustomer = idCustomer;
        IdCalendary = idCalendary;
    }
    
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int IdRoom { get; set; }
    public int IdCustomer { get; set; }
    public int IdCalendary { get; set; }
    
    public Core.Entities.Reservation ToEntity()
        => new(StartDate, EndDate, IdRoom, IdCustomer, IdCalendary);
}