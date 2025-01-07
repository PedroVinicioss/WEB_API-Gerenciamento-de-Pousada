using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.ViewModels;
using GerenciadorHotel.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHotel.Application.Interfaces.Cash.Queries.GetCashById;

public class GetCashByIdQueryHandler : IRequestHandler<GetCashByIdQuery, ResultViewModel<CashViewModel>>
{
    private readonly AppDbContext _context;
    
    public GetCashByIdQueryHandler(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<ResultViewModel<CashViewModel>> Handle(GetCashByIdQuery request, CancellationToken cancellationToken)
    {
        var cash = await _context.Cash.FirstOrDefaultAsync(c => c.Id == request.Id && !c.IsDeleted, cancellationToken: cancellationToken);
        
        if (cash is null)
            return ResultViewModel<CashViewModel>.Error("Cash não encontrada.");
        
        
        return ResultViewModel<CashViewModel>.Success(CashViewModel.FromEntity(cash));
    }
}