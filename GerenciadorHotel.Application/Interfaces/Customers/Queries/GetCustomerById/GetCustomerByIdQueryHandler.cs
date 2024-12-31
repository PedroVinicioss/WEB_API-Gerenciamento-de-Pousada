using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.ViewModels;
using GerenciadorHotel.Infrastructure.Persistence;
using GerenciadorHotel.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHotel.Application.Interfaces.Customers.Queries.GetCustomerById;

public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, ResultViewModel<CustomerViewModel>>
{
    private readonly AppDbContext _context;

    public GetCustomerByIdQueryHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ResultViewModel<CustomerViewModel>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .Include(u => (u as Core.Entities.Customer).Reservations)
            .ThenInclude(r => r.Room)
            .SingleOrDefaultAsync(u => u.Id == request.Id, cancellationToken: cancellationToken);
        
        if (user is null)
            return ResultViewModel<CustomerViewModel>.Error("Usuário não encontrado.");

        var userViewModel = CustomerViewModel.FromEntity((Core.Entities.Customer)user);
        return ResultViewModel<CustomerViewModel>.Success(userViewModel);
    }
}