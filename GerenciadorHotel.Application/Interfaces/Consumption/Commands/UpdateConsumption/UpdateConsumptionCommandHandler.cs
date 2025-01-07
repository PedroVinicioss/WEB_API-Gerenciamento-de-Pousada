using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHotel.Application.Interfaces.Consumption.Commands.UpdateConsumption;

public class UpdateConsumptionCommandHandler : IRequestHandler<UpdateConsumptionCommand, ResultViewModel>
{
    private readonly AppDbContext _context;
    
    public UpdateConsumptionCommandHandler(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<ResultViewModel> Handle(UpdateConsumptionCommand request, CancellationToken cancellationToken)
    {
        var consumption = await _context.Consumptions.SingleOrDefaultAsync(c => c.Id == request.Id, cancellationToken: cancellationToken);
        if(consumption is null)
            return ResultViewModel.Error("Consumo não encontrado");
        
        consumption.Update(request.ToEntity(consumption.Value));
        
        _context.Update(consumption);
        await _context.SaveChangesAsync(cancellationToken);
        
        return ResultViewModel.Success();
    }
}