using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHotel.Application.Interfaces.User.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ResultViewModel>
{
    private readonly AppDbContext _context;
    
    public UpdateUserCommandHandler(AppDbContext context)
    {
        _context = context;
    }
    public async Task<ResultViewModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
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