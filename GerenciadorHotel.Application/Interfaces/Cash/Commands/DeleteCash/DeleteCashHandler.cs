using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Infrastructure.Persistence;
using MediatR;

namespace GerenciadorHotel.Application.Interfaces.Cash.Commands.DeleteCash;

public class DeleteCashHandler : IRequestHandler<DeleteCashCommand, ResultViewModel>
{
    private readonly AppDbContext _context;

    public DeleteCashHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ResultViewModel> Handle(DeleteCashCommand request, CancellationToken cancellationToken)
    {
        var cash = await _context.Cash.FindAsync(request.Id);

        if (cash == null)
        {
            return ResultViewModel.Error("Cash não encontrado.");
        }

        cash.SetAsDelete();
        
        _context.Cash.Update(cash);
        await _context.SaveChangesAsync(cancellationToken);

        return ResultViewModel.Success();
    }
}