using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.ViewModels;
using MediatR;

namespace GerenciadorHotel.Application.Interfaces.Room.Queries.GetAllRooms;

public class GetAllRoomsQuery : IRequest<ResultViewModel<List<RoomViewModel>>>
{
    public GetAllRoomsQuery(string search)
    {
        Search = search;
    }
    public string Search { get; set; }
}