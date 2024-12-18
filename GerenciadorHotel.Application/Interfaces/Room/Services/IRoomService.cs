﻿using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.InputModels;
using GerenciadorHotel.Application.Models.ViewModels;

namespace GerenciadorHotel.Application.Interfaces.Room.Services;

public interface IRoomService
{
    ResultViewModel<List<RoomViewModel>> GetAll(string search = "");
    ResultViewModel<RoomViewModel> GetById(int id);
    ResultViewModel<int> Insert(CreateRoomInputModel model);
    ResultViewModel Update(Core.Entities.Room model);
    ResultViewModel Delete(int id);
}