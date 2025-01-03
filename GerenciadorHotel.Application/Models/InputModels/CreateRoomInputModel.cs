﻿using GerenciadorHotel.Core.Entities;
using GerenciadorHotel.Core.Enums;

namespace GerenciadorHotel.Application.Models.InputModels;

public class CreateRoomInputModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal DaylyValue { get; set; }
    public int Capacity { get; set; }
    public RoomTypeEnum Type { get; set; }
    
    public Room ToEntity()
        => new(Name, Description, true, DaylyValue, Capacity, Type);
}