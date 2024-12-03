using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.InputModels;
using GerenciadorHotel.Application.Models.ViewModels;
using GerenciadorHotel.Core.Entities;

namespace GerenciadorHotel.Application.Services;

public interface IReservationService
{
    ResultViewModel<List<ReservationViewModel>> GetAll();
    ResultViewModel<ReservationViewModel> GetById(int id);
    ResultViewModel<int> Insert(CreateReservationInputModel model);
    ResultViewModel Update(Reservation model);
    ResultViewModel Delete(int id);
}