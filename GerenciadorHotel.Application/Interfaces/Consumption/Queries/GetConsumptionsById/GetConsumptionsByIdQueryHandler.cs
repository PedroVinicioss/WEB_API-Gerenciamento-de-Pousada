using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.ViewModels;
using GerenciadorHotel.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHotel.Application.Interfaces.Consumption.Queries.GetConsumptionsById;

public class GetConsumptionsByIdQueryHandler : IRequestHandler<GetConsumptionsByIdQuery, ResultViewModel<ConsumptionViewModel>>
{
    private readonly AppDbContext _context;
    
    public GetConsumptionsByIdQueryHandler(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<ResultViewModel<ConsumptionViewModel>> Handle(GetConsumptionsByIdQuery request, CancellationToken cancellationToken)
    {
        var consumption = await _context.Consumptions
            .Where(c => !c.IsDeleted)
            .Include(c => c.Product)
            .Include(c => c.Reservation)
            .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
        
        if (consumption is null)
            return ResultViewModel<ConsumptionViewModel>.Error("Consumo não encontrado");
        
        
        return ResultViewModel<ConsumptionViewModel>.Success(ConsumptionViewModel.FromEntity(consumption));
    }
}