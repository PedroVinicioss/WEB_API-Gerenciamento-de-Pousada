using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.ViewModels;
using GerenciadorHotel.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHotel.Application.Interfaces.Product.Queries.GetAllProducts;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, ResultViewModel<List<ProductViewModel>>>
{
    private readonly AppDbContext _context;

    public GetAllProductsQueryHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ResultViewModel<List<ProductViewModel>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _context.Products
            .Where(p => !p.IsDeleted && (request.Search == "" || p.Name.Contains(request.Search) || p.Description.Contains(request.Search)))
            .Select(p => ProductViewModel.FromEntity(p))
            .ToListAsync(cancellationToken);

        return ResultViewModel<List<ProductViewModel>>.Success(products);
    }
}