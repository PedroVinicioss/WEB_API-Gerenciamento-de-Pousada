using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHotel.Application.Interfaces.User.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ResultViewModel>
{
    private readonly AppDbContext _context;
    
    public DeleteUserCommandHandler(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<ResultViewModel> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
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