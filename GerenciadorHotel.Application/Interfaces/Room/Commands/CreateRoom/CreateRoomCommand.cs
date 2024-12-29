using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Core.Enums;
using MediatR;

namespace GerenciadorHotel.Application.Interfaces.Room.Commands.CreateRoom;

public class CreateRoomCommand : IRequest<ResultViewModel<int>>
{
    public CreateRoomCommand(string name, string description, decimal daylyValue, int capacity, RoomTypeEnum type)
    {
        Name = name;
        Description = description;
        DaylyValue = daylyValue;
        Capacity = capacity;
        Type = type;
    }
    
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal DaylyValue { get; set; }
    public int Capacity { get; set; }
    public RoomTypeEnum Type { get; set; }
    
    public Core.Entities.Room ToEntity()
        => new(Name, Description, true, DaylyValue, Capacity, Type);
}