using GerenciadorHotel.Core.Entities;
using GerenciadorHotel.Core.Enums;

namespace GerenciadorHotel.Application.Models.InputModels;

public class UpdateRoomInputModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal DaylyValue { get; set; }
    public int Capacity { get; set; }
    public bool IsAvailable { get; set; }
    public RoomTypeEnum Type { get; set; }
    
    public Room ToEntity()
        => new(Name, Description, IsAvailable, DaylyValue, Capacity, Type);
}