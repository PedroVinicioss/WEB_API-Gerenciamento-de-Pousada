using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHotel.Application.Interfaces.Product.Commands.DeleteProduct;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ResultViewModel>
{
    private readonly AppDbContext _context;

    public DeleteProductCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ResultViewModel> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.SingleOrDefaultAsync(p => !p.IsDeleted && p.Id == request.Id, cancellationToken: cancellationToken);
        if(product is null)
            return ResultViewModel.Error("Produto não encontrado");

        product.SetAsDelete();
        
        _context.Update(product);
        await _context.SaveChangesAsync(cancellationToken);

        return ResultViewModel.Success();
    }
}