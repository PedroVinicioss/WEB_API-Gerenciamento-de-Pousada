using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.ViewModels;
using GerenciadorHotel.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHotel.Application.Interfaces.Customers.Queries.GetAllCustomers;

public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, ResultViewModel<List<CustomerItemViewModel>>>
{
    private readonly AppDbContext _context;

    public GetAllCustomersQueryHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ResultViewModel<List<CustomerItemViewModel>>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        if(request.Search is null)
            request.Search = "";
        
        var viewModel = await _context.Users
            .Where(u => !u.IsDeleted && (request.Search == "" || u.FullName.Contains(request.Search) || u.Email.Contains(request.Search) || u.Phone.Contains(request.Search) || u.MobilePhone.Contains(request.Search) || u.Document.Contains(request.Search)  || (u is Core.Entities.Customer && ((Core.Entities.Customer)u).Profession.Contains(request.Search))))
            .Select(u => CustomerItemViewModel.FromEntity(u as Core.Entities.Customer))
            .ToListAsync(cancellationToken: cancellationToken);

        return ResultViewModel<List<CustomerItemViewModel>>.Success(viewModel);
    }
}