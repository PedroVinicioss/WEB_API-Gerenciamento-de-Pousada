using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Infrastructure.Persistence;
using MediatR;

namespace GerenciadorHotel.Application.Interfaces.Cash.Commands.UpdateCash;

public class UpdateCashCommandHandler : IRequestHandler<UpdateCashCommand, ResultViewModel>
{
    private readonly AppDbContext _context;
    
    public UpdateCashCommandHandler(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<ResultViewModel> Handle(UpdateCashCommand request, CancellationToken cancellationToken)
    {
        var cash = request.ToEntity();
        var cashEntity = _context.Cash
            .SingleOrDefault(c => c.Id == request.Id && !c.IsDeleted);
        if (cashEntity is null)
            return ResultViewModel.Error("Caixa não encontrado");

        cashEntity.Update(cash);
        await _context.SaveChangesAsync(cancellationToken);
        
        return ResultViewModel.Success();
    }
}