﻿using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.InputModels;
using GerenciadorHotel.Application.Models.ViewModels;
using GerenciadorHotel.Core.Entities;

namespace GerenciadorHotel.Application.Services;

public interface IRoomService
{
    ResultViewModel<List<RoomViewModel>> GetAll(string search = "");
    ResultViewModel<RoomViewModel> GetById(int id);
    ResultViewModel<int> Insert(CreateRoomInputModel model);
    ResultViewModel Update(Room model);
    ResultViewModel Delete(int id);
}