using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHotel.Application.Interfaces.Reservation.Commands.UpdateReservation;

public class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand, ResultViewModel>
{
    private readonly AppDbContext _context;
    
    public UpdateReservationCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ResultViewModel> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
    {
        var reservation = await _context.Reservations.SingleOrDefaultAsync(r => r.Id == request.Id, cancellationToken: cancellationToken);
        if(reservation is null)
            return ResultViewModel.Error("Reserva não encontrada");
        
        reservation.Update(request.ToEntity());
        
        _context.Update(reservation);
        await _context.SaveChangesAsync(cancellationToken);
        
        return ResultViewModel.Success();
    }
}