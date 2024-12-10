using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.ViewModels;

namespace GerenciadorHotel.Application.Interfaces.Cash.Services;

public interface ICashService
{
    ResultViewModel<List<CashViewModel>> GetAll();
    ResultViewModel<CashViewModel> GetById(int id);
    ResultViewModel<CashViewModel> CreateCashForMonth(Core.Entities.Cash model);
    ResultViewModel<CashViewModel> UpdateCashForMonth(Core.Entities.Cash model);
    ResultViewModel<CashViewModel> DeleteCashForMonth(int id);
}