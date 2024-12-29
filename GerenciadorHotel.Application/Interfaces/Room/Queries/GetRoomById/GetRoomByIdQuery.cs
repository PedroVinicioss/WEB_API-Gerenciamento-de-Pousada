using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.ViewModels;
using MediatR;

namespace GerenciadorHotel.Application.Interfaces.Room.Queries.GetRoomById;

public class GetRoomByIdQuery : IRequest<ResultViewModel<RoomViewModel>>
{
    public GetRoomByIdQuery(int id)
    {
        Id = id;
    }
    
    public int Id { get; set; }
}