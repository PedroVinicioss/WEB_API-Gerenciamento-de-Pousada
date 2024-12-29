using GerenciadorHotel.Application.Models;
using MediatR;

namespace GerenciadorHotel.Application.Interfaces.Reservation.Commands.DeleteReservation;

public class DeleteReservationCommand : IRequest<ResultViewModel>
{
    public DeleteReservationCommand(int id)
    {
        Id = id;
    }
    
    public int Id { get; set; }
}