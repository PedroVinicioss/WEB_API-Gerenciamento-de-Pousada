using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.ViewModels;
using GerenciadorHotel.Application.Models.InputModels;
using GerenciadorHotel.Core.Entities;

namespace GerenciadorHotel.Application.Services;

public interface IConsumptionService
{
    ResultViewModel<List<ConsumptionViewModel>> GetAll();
    ResultViewModel<ConsumptionViewModel> GetById(int id);
    ResultViewModel<int> Insert(CreateConsumptionInputModel model);
    ResultViewModel Update(Consumption model);
    ResultViewModel Delete(int id);
}