using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.ViewModels;
using GerenciadorHotel.Core.Entities;

namespace GerenciadorHotel.Application.Services;

public interface ICashService
{
    ResultViewModel<List<CashViewModel>> GetAll();
    ResultViewModel<CashViewModel> GetById(int id);
    ResultViewModel<CashViewModel> CreateCashForMonth(Cash model);
    ResultViewModel<CashViewModel> UpdateCashForMonth(Cash model);
    ResultViewModel<CashViewModel> DeleteCashForMonth(int id);
}