using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHotel.Application.Interfaces.Cash.Queries.GetCashByMonth;

public class GetCashByMonthQueryHandler : IRequestHandler<GetCashByMonthQuery, ResultViewModel<int>>
{
    private readonly AppDbContext _context;
    
    public GetCashByMonthQueryHandler(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<ResultViewModel<int>> Handle(GetCashByMonthQuery request, CancellationToken cancellationToken)
    {
        var monthYear = $"{request.Month:D2}/{request.Year}"; 
        var cash = await _context.Cash
            .SingleOrDefaultAsync(c => c.Month == monthYear && !c.IsDeleted, cancellationToken: cancellationToken);
        if (cash == null)
            return ResultViewModel<int>.Error("Caixa não encontrado");

        return ResultViewModel<int>.Success(cash.Id);
    }
}