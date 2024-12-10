using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.InputModels;
using GerenciadorHotel.Application.Models.ViewModels;

namespace GerenciadorHotel.Application.Interfaces.Consumption.Services;

public interface IConsumptionService
{
    ResultViewModel<List<ConsumptionViewModel>> GetAll();
    ResultViewModel<ConsumptionViewModel> GetById(int id);
    ResultViewModel<int> Insert(CreateConsumptionInputModel model);
    ResultViewModel Update(Core.Entities.Consumption model);
    ResultViewModel Delete(int id);
}