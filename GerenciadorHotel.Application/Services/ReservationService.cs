using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.InputModels;
using GerenciadorHotel.Application.Models.ViewModels;
using GerenciadorHotel.Core.Entities;
using GerenciadorHotel.Infrastructure.Persistence;

namespace GerenciadorHotel.Application.Services;

public class ReservationService : IReservationService
{
    private AppDbContext _context;

    public ReservationService(AppDbContext context)
    {
        _context = context;
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
        
        _context.Reservations.Add(reservation);
        _context.SaveChanges();
        
        return ResultViewModel<int>.Success(reservation.Id);
    }
    
    public ResultViewModel Update(Reservation model)
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