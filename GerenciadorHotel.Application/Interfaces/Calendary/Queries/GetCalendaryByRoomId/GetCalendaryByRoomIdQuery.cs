using GerenciadorHotel.Application.Models;
using MediatR;

namespace GerenciadorHotel.Application.Interfaces.Calendary.Queries.GetCalendaryByRoomId;

public class GetCalendaryByRoomIdQuery : IRequest<ResultViewModel<Core.Entities.Calendary>>
{
    public GetCalendaryByRoomIdQuery(int id)
    {
        Id = Id;
    }

    public int Id { get; set; }
}