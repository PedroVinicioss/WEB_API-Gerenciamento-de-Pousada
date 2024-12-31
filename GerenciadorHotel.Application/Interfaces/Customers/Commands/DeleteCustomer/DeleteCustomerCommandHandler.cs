using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Infrastructure.Persistence;
using MediatR;

namespace GerenciadorHotel.Application.Interfaces.Customers.Commands.DeleteCustomer;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, ResultViewModel>
{
    private readonly AppDbContext _context;
    
    public DeleteCustomerCommandHandler(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<ResultViewModel> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var user =  _context.Users.SingleOrDefault(u => u.Id == request.Id);
        if(user is null)
            return ResultViewModel.Error("Usuário não encontrado");
        
        user.SetAsDelete();
        
        _context.Update(user);
        await _context.SaveChangesAsync(cancellationToken);
        
        return ResultViewModel.Success();
    }
}