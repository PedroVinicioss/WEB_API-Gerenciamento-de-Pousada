using GerenciadorHotel.Application.Models;
using MediatR;

namespace GerenciadorHotel.Application.Interfaces.Reservation.Commands.UpdateReservation;

public class UpdateReservationCommand : IRequest<ResultViewModel>
{
    public UpdateReservationCommand(int id, DateTime startDate, DateTime endDate, int idRoom, int idCustomer, int idCalendary)
    {
        Id = id;
        StartDate = startDate;
        EndDate = endDate;
        IdRoom = idRoom;
        IdCustomer = idCustomer;
        IdCalendary = idCalendary;
    }

    public int Id { get; set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public decimal TotalCost { get; private set; }
    public int IdRoom { get; private set; }
    public int IdCustomer { get; private set; }
    public int IdCalendary { get; private set; }
    
    public Core.Entities.Reservation ToEntity()
        => new(StartDate, EndDate, IdRoom, IdCustomer, IdCalendary);
}