using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHotel.Application.Interfaces.Consumption.Commands.CreateConsumption;

public class CreateConsumptionCommandHandler : IRequestHandler<CreateConsumptionCommand, ResultViewModel<int>>
{
    private readonly AppDbContext _context;
    
    public CreateConsumptionCommandHandler(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<ResultViewModel<int>> Handle(CreateConsumptionCommand request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.SingleOrDefaultAsync(p => p.Id == request.IdProduct, cancellationToken: cancellationToken);
        if(product is null)
            return ResultViewModel<int>.Error("Produto não encontrado");
        
        var reservation = await _context.Reservations.SingleOrDefaultAsync(r => r.Id == request.IdReservation, cancellationToken: cancellationToken);
        if(reservation is null)
            return ResultViewModel<int>.Error("Reserva não encontrada");
        
        var value = request.Quantity * product.Price;
        var consumption = request.ToEntity(value);
        
        _context.Consumptions.Add(consumption);
        await _context.SaveChangesAsync(cancellationToken);
        
        return ResultViewModel<int>.Success(consumption.Id);
    }
}