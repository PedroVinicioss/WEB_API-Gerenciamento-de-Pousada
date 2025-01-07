using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.ViewModels;
using GerenciadorHotel.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHotel.Application.Interfaces.Cash.Queries.GetAllCash;

public class GetAllCashQueryHandler : IRequestHandler<GetAllCashQuery, ResultViewModel<List<CashViewModel>>>
{
    private readonly AppDbContext _context;
    
    public GetAllCashQueryHandler(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<ResultViewModel<List<CashViewModel>>> Handle(GetAllCashQuery request, CancellationToken cancellationToken)
    {
        var cash = await _context.Cash
            .Where(c => !c.IsDeleted && (request.Search == "" || c.ClosingDate.Equals(request.Search) || c.OpeningDate.Equals(request.Search)))
            .Select(c => CashViewModel.FromEntity(c))
            .ToListAsync(cancellationToken);
        
        return ResultViewModel<List<CashViewModel>>.Success(cash);
    }
}