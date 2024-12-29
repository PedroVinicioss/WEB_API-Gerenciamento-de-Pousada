using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.ViewModels;
using GerenciadorHotel.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHotel.Application.Interfaces.Reservation.Queries.GetReservationsById;

public class GetReservationsByIdQueryHandler : IRequestHandler<GetReservationsByIdQuery, ResultViewModel<ReservationViewModel>>
{
    private readonly AppDbContext _context;
    
    public GetReservationsByIdQueryHandler(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<ResultViewModel<ReservationViewModel>> Handle(GetReservationsByIdQuery request, CancellationToken cancellationToken)
    {
        var reservation = await _context.Reservations
            .Include(r => r.Customer)
            .Include(r => r.Room)
            .SingleOrDefaultAsync(r => r.Id == request.Id, cancellationToken: cancellationToken);
        if(reservation is null)
            return ResultViewModel<ReservationViewModel>.Error("Reserva não encontrada");
        
        var model = ReservationViewModel.FromEntity(reservation);
        
        return ResultViewModel<ReservationViewModel>.Success(model);
    }
}