using GerenciadorHotel.Application.Interfaces.Cash.Services;
using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.InputModels;
using GerenciadorHotel.Application.Models.ViewModels;
using GerenciadorHotel.Infrastructure.Persistence;

namespace GerenciadorHotel.Application.Interfaces.Reservation.Services;

public class ReservationService : IReservationService
{
    private AppDbContext _context;
    private ICashService _cashService;

    public ReservationService(AppDbContext context, ICashService cashService)
    {
        _context = context;
        _cashService = cashService;
    }
    
    public ResultViewModel<List<ReservationViewModel>> GetAll()
    {
        var reservations = _context.Reservations
            .Where(r => !r.IsDeleted)
            .Select(r => ReservationViewModel.FromEntity(r))
            .ToList();

        return ResultViewModel<List<ReservationViewModel>>.Success(reservations);
    }

    public ResultViewModel<ReservationViewModel> GetById(int id)
    {
        var reservation = _context.Reservations.SingleOrDefault(r => r.Id == id);
        if(reservation is null)
            return ResultViewModel<ReservationViewModel>.Error("Reserva não encontrada");
        
        var model = ReservationViewModel.FromEntity(reservation);
        
        return ResultViewModel<ReservationViewModel>.Success(model);
    }


    public ResultViewModel<int> Insert(CreateReservationInputModel model)
    {
        var reservation = model.ToEntity();
    
        // Obtém o mês e ano atual
        var now = DateTime.Now;
        var result = _cashService.GetCashByMonth(now.Month, now.Year);
        var idCash = 0;

        if (result.IsSuccess)
            idCash = result.Data; 
    
        reservation.SetCash(idCash);

        _context.Reservations.Add(reservation);
        _context.SaveChanges();

        return ResultViewModel<int>.Success(reservation.Id);
    }
    
    public ResultViewModel Update(Core.Entities.Reservation model)
    {
        var reservation = _context.Reservations.SingleOrDefault(r => r.Id == model.Id);
        if(reservation is null)
            return ResultViewModel.Error("Reserva não encontrada");
        
        reservation.Update(model);
        
        _context.Update(reservation);
        _context.SaveChanges();
        
        return ResultViewModel.Success();
    }
    
    public ResultViewModel Delete(int id)
    {
        var reservation = _context.Reservations.SingleOrDefault(r => r.Id == id);
        if(reservation is null)
            return ResultViewModel.Error("Reserva não encontrada");
        
        reservation.SetAsDelete();
        
        _context.Update(reservation);
        _context.SaveChanges();
        
        return ResultViewModel.Success();
    }
}