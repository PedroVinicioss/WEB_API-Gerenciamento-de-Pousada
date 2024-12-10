using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.InputModels;
using GerenciadorHotel.Application.Models.ViewModels;

namespace GerenciadorHotel.Application.Interfaces.Reservation.Services;

public interface IReservationService
{
    ResultViewModel<List<ReservationViewModel>> GetAll();
    ResultViewModel<ReservationViewModel> GetById(int id);
    ResultViewModel<int> Insert(CreateReservationInputModel model);
    ResultViewModel Update(Core.Entities.Reservation model);
    ResultViewModel Delete(int id);
}