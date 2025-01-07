using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.ViewModels;
using GerenciadorHotel.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHotel.Application.Interfaces.Consumption.Queries.GetAllConsumptions;

public class GetAllConsumptionsQueryHandler : IRequestHandler<GetAllConsumptionsQuery, ResultViewModel<List<ConsumptionViewModel>>>
{
    private readonly AppDbContext _context;

    public GetAllConsumptionsQueryHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ResultViewModel<List<ConsumptionViewModel>>> Handle(GetAllConsumptionsQuery request, CancellationToken cancellationToken)
    {
        var consumptions = await _context.Consumptions
            .Where(c => !c.IsDeleted && (request.Search == "" || c.Product.Name.Contains(request.Search) || c.Reservation.Customer.FullName.Contains(request.Search)))
            .Select(c => ConsumptionViewModel.FromEntity(c))
            .ToListAsync(cancellationToken);

        return ResultViewModel<List<ConsumptionViewModel>>.Success(consumptions);
    }
}