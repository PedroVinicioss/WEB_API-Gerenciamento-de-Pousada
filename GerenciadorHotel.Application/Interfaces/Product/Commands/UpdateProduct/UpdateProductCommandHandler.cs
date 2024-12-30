using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHotel.Application.Interfaces.Product.Commands.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ResultViewModel>
{
    private readonly AppDbContext _context;

    public UpdateProductCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ResultViewModel> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.SingleOrDefaultAsync(p => !p.IsDeleted && p.Id == request.Id, cancellationToken: cancellationToken);
        if(product is null)
            return ResultViewModel.Error("Produto não encontrado");
        
        product.Update(request.Name, request.Description, request.Price, request.IsAvailable, request.Category, request.Stock);
        
        _context.Update(product);
        await _context.SaveChangesAsync(cancellationToken);
        
        return ResultViewModel.Success();
    }
}