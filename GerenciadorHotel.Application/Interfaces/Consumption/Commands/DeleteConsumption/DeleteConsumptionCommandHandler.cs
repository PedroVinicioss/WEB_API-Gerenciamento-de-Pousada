using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHotel.Application.Interfaces.Consumption.Commands.DeleteConsumption;

public class DeleteConsumptionCommandHandler : IRequestHandler<DeleteConsumptionCommand, ResultViewModel>
{
    private readonly AppDbContext _context;
    
    public DeleteConsumptionCommandHandler(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<ResultViewModel> Handle(DeleteConsumptionCommand request, CancellationToken cancellationToken)
    {
        var consumption = await _context.Consumptions.SingleOrDefaultAsync(c => c.Id == request.Id, cancellationToken: cancellationToken);
        if(consumption is null)
            return ResultViewModel.Error("Consumo não encontrado");
        
        consumption.SetAsDelete();
        await _context.SaveChangesAsync(cancellationToken);
        
        return ResultViewModel.Success();
    }
}