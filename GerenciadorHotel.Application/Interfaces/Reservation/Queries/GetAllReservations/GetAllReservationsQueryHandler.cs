using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.ViewModels;
using GerenciadorHotel.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHotel.Application.Interfaces.Reservation.Queries.GetAllReservations;

public class GetAllReservationsQueryHandler : IRequestHandler<GetAllReservationsQuery, ResultViewModel<List<ReservationViewModel>>>
{
    private readonly AppDbContext _context;
    
    public GetAllReservationsQueryHandler(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<ResultViewModel<List<ReservationViewModel>>> Handle(GetAllReservationsQuery request, CancellationToken cancellationToken)
    {
        var reservations = await _context.Reservations
            .Where(r => !r.IsDeleted)
            .Include(r => r.Customer)
            .Include(r => r.Room)
            .Select(r => ReservationViewModel.FromEntity(r))
            .ToListAsync(cancellationToken: cancellationToken);

        return ResultViewModel<List<ReservationViewModel>>.Success(reservations);
    }
}