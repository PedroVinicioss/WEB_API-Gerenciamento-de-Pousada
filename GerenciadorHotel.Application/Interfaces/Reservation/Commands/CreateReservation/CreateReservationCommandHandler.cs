using GerenciadorHotel.Application.Interfaces.Cash.Services;
using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Infrastructure.Persistence;
using MediatR;

namespace GerenciadorHotel.Application.Interfaces.Reservation.Commands.CreateReservation;

public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, ResultViewModel<int>>
{
    private readonly AppDbContext _context;
    private readonly ICashService _cashService;
    
    public CreateReservationCommandHandler(AppDbContext context, ICashService cashService)
    {
        _context = context;
        _cashService = cashService;
    }
    
    public async Task<ResultViewModel<int>> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        var reservation = request.ToEntity();
    
        // Obtém o mês e ano atual
        var now = DateTime.Now;
        var result = _cashService.GetCashByMonth(now.Month, now.Year);
        var idCash = 0;

        if (!result.IsSuccess)
            return ResultViewModel<int>.Error("Erro ao obter o caixa");
            
        idCash = result.Data; 
        reservation.SetCash(idCash);

        _context.Reservations.Add(reservation);
        await _context.SaveChangesAsync(cancellationToken);

        return ResultViewModel<int>.Success(reservation.Id);
    }
}