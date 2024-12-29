using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.ViewModels;
using MediatR;

namespace GerenciadorHotel.Application.Interfaces.Reservation.Queries.GetAllReservations;

public class GetAllReservationsQuery : IRequest<ResultViewModel<List<ReservationViewModel>>>
{
    public GetAllReservationsQuery(string search)
    {
        Search = search;
    }
    public string Search { get; set; }
}