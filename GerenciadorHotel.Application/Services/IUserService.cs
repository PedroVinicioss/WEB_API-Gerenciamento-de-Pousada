﻿using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.InputModels;
using GerenciadorHotel.Application.Models.ViewModels;
using GerenciadorHotel.Core.Entities;

namespace GerenciadorHotel.Application.Services;

public interface IUserService
{
    ResultViewModel<List<UserItemViewModel>> GetAll(string search = "");
    ResultViewModel<UserViewModel> GetById(int id);
    ResultViewModel<int> Insert(CreateUserInputModel model);
    ResultViewModel Update(User model);
    ResultViewModel Delete(int id);
}