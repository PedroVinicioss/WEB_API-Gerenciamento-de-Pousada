using GerenciadorHotel.Application.Interfaces.Cash.Queries.GetCashByMonth;
using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Infrastructure.Persistence;
using MediatR;

namespace GerenciadorHotel.Application.Interfaces.Reservation.Commands.CreateReservation;

public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, ResultViewModel<int>>
{
    private readonly AppDbContext _context;
    private readonly IMediator _mediator;
    
    public CreateReservationCommandHandler(AppDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }
    
    public async Task<ResultViewModel<int>> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        var reservation = request.ToEntity();
    
        // Obtém o mês e ano atual
        var now = DateTime.Now;
        var result = await _mediator.Send(new GetCashByMonthQuery(now.Month, now.Year), cancellationToken);

        if (!result.IsSuccess)
            return ResultViewModel<int>.Error("Erro ao obter o caixa");
            
        var idCash = result.Data; 
        reservation.SetCash(idCash);

        _context.Reservations.Add(reservation);
        await _context.SaveChangesAsync(cancellationToken);

        return ResultViewModel<int>.Success(reservation.Id);
    }
}