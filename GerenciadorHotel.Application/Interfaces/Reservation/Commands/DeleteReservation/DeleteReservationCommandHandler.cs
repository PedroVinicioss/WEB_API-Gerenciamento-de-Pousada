using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHotel.Application.Interfaces.Reservation.Commands.DeleteReservation;

public class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand, ResultViewModel>
{
    private readonly AppDbContext _context;
    
    public DeleteReservationCommandHandler(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<ResultViewModel> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
    {
        var reservation = await _context.Reservations.SingleOrDefaultAsync(r => r.Id == request.Id, cancellationToken);
        if (reservation is null)
            return ResultViewModel.Error("Reserva não encontrada");
        
        reservation.SetAsDelete();
        
        _context.Update(reservation);
        await _context.SaveChangesAsync(cancellationToken);
        
        return ResultViewModel.Success();
    }
}