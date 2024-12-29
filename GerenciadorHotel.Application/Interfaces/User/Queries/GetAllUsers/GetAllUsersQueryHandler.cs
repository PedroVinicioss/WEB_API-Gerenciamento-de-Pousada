using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.ViewModels;
using GerenciadorHotel.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHotel.Application.Interfaces.User.Queries.GetAllUsers;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, ResultViewModel<List<UserItemViewModel>>>
{
    private readonly AppDbContext _context;

    public GetAllUsersQueryHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ResultViewModel<List<UserItemViewModel>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        if(request.Search is null)
            request.Search = "";
        
        var viewModel = await _context.Users
            .Where(u => !u.IsDeleted && (request.Search == "" || u.FullName.Contains(request.Search) || u.Email.Contains(request.Search) || u.Phone.Contains(request.Search) || u.MobilePhone.Contains(request.Search) || u.Cpf.Contains(request.Search) || u.Rg.Contains(request.Search) || u.Profession.Contains(request.Search)))
            .Select(u => UserItemViewModel.FromEntity(u))
            .ToListAsync(cancellationToken: cancellationToken);

        return ResultViewModel<List<UserItemViewModel>>.Success(viewModel);
    }
}