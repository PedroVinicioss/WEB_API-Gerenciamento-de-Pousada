using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Infrastructure.Persistence;
using MediatR;

namespace GerenciadorHotel.Application.Interfaces.Product.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ResultViewModel<int>>
{
    private readonly AppDbContext _context;
    
    public CreateProductCommandHandler(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<ResultViewModel<int>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = request.ToEntity();
        
        _context.Products.Add(product);
        await _context.SaveChangesAsync(cancellationToken);
        
        return ResultViewModel<int>.Success(product.Id);
    }
}