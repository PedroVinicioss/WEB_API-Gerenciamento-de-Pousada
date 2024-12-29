using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.ViewModels;
using MediatR;

namespace GerenciadorHotel.Application.Interfaces.Reservation.Queries.GetReservationsById;

public class GetReservationsByIdQuery : IRequest<ResultViewModel<ReservationViewModel>>
{
    public GetReservationsByIdQuery(int id)
    {
        Id = id;
    }
    
    public int Id { get; set; }
}