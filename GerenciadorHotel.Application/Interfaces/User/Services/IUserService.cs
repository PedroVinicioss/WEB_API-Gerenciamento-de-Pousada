using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.InputModels;
using GerenciadorHotel.Application.Models.ViewModels;

namespace GerenciadorHotel.Application.Interfaces.User.Services;

public interface IUserService
{
    ResultViewModel<List<UserItemViewModel>> GetAll(string search = "");
    ResultViewModel<UserViewModel> GetById(int id);
    ResultViewModel<int> Insert(CreateUserInputModel model);
    ResultViewModel Update(Core.Entities.User model);
    ResultViewModel Delete(int id);
    ResultViewModel<int> Authenticate(string email, string password);
}