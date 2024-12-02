using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.InputModels;
using GerenciadorHotel.Application.Models.ViewModels;

namespace GerenciadorHotel.Application.Services;

public class IUserService
{
    ResultViewModel<List<UserItemViewModel>> GetAll(string search = "");
    ResultViewModel<UserViewModel> GetById(int id);
    ResultViewModel<int> Insert(CreateUserInputModel inputModel);
    //ResultViewModel Update(UpdateUserInputModel inputModel);
    ResultViewModel Delete(int id);
}