using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHotel.Application.Interfaces.Customers.Commands.UpdateCustomer;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, ResultViewModel>
{
    private readonly AppDbContext _context;
    
    public UpdateCustomerCommandHandler(AppDbContext context)
    {
        _context = context;
    }
    public async Task<ResultViewModel> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == request.Id);
        if(user is null)
            return ResultViewModel.Error("Usuário não encontrado"); ;
        
        user.Update(request.ToEntity());
        
        _context.Update(user);
        await _context.SaveChangesAsync(cancellationToken);
        
        return ResultViewModel.Success();
    }
}