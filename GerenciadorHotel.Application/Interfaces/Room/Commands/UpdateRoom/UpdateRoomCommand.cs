using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.ViewModels;
using GerenciadorHotel.Core.Enums;
using MediatR;

namespace GerenciadorHotel.Application.Interfaces.Room.Commands.UpdateRoom;

public class UpdateRoomCommand : IRequest<ResultViewModel>
{
    public UpdateRoomCommand(int id, string roomName, string description, bool isAvailable, decimal daylyValue, int capacity, RoomTypeEnum type)
    {
        Id = id;
        RoomName = roomName;
        Description = description;
        IsAvailable = isAvailable;
        DaylyValue = daylyValue;
        Capacity = capacity;
        Type = type;
    }

    public int Id { get; set; }
    public string RoomName { get; set; }
    public string Description { get; set; }
    public bool IsAvailable { get; set; }
    public decimal DaylyValue { get; set; }
    public int Capacity { get; set; }
    public RoomTypeEnum Type { get; set; }
    
    public Core.Entities.Room ToEntity()
        => new(RoomName, Description, IsAvailable, DaylyValue, Capacity, Type);
}