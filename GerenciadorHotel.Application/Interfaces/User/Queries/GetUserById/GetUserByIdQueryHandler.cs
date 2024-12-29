using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.ViewModels;
using GerenciadorHotel.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHotel.Application.Interfaces.User.Queries.GetUserById;

public class GetUserByIdQueryHandler : IRequest<ResultViewModel<UserViewModel>>
{
    private readonly AppDbContext _context;

    public GetUserByIdQueryHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ResultViewModel<UserViewModel>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .Include(u => u.Reservations)
            .ThenInclude(r => r.Room)
            .Include(u => u.Partners)
            .SingleOrDefaultAsync(u => u.Id == request.Id, cancellationToken: cancellationToken);
        
        if(user is null)
            return ResultViewModel<UserViewModel>.Error("Usuário não encontrado");
        
        var model = UserViewModel.FromEntity(user);
        
        return ResultViewModel<UserViewModel>.Success(model);
    }
}