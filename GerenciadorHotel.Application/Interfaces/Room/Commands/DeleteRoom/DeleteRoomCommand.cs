using GerenciadorHotel.Application.Models;
using MediatR;

namespace GerenciadorHotel.Application.Interfaces.Room.Commands.DeleteRoom;

public class DeleteRoomCommand : IRequest<ResultViewModel>
{
    public DeleteRoomCommand(int id)
    {
        Id = id;
    }
    
    public int Id { get; set; }
}