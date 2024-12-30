using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.ViewModels;
using GerenciadorHotel.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHotel.Application.Interfaces.Product.Queries.GetProductsById;

public class GetProductsByIdHandler : IRequestHandler<GetProductsById, ResultViewModel<ProductViewModel>>
{
    private readonly AppDbContext _context;
    
    public GetProductsByIdHandler(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<ResultViewModel<ProductViewModel>> Handle(GetProductsById request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.SingleOrDefaultAsync(p => !p.IsDeleted && p.Id == request.Id, cancellationToken: cancellationToken);
        if(product is null)
            return ResultViewModel<ProductViewModel>.Error("Produto não encontrado");
        
        var model = ProductViewModel.FromEntity(product);
        
        return ResultViewModel<ProductViewModel>.Success(model);
    }
}