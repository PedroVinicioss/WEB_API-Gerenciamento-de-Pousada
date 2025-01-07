using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Infrastructure.Persistence;
using MediatR;

namespace GerenciadorHotel.Application.Interfaces.Cash.Commands.CreateCash;

public class CreateCashCommandHandler : IRequestHandler<CreateCashCommand, ResultViewModel<int>>
{
    private readonly AppDbContext _context;

    public CreateCashCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ResultViewModel<int>> Handle(CreateCashCommand request, CancellationToken cancellationToken)
    {
        var cash = request.ToEntity();
        _context.Cash.Add(cash);
        await _context.SaveChangesAsync(cancellationToken);

        return ResultViewModel<int>.Success(cash.Id);
    }
}