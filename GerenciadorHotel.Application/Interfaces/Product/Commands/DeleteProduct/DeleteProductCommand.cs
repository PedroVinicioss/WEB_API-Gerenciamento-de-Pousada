using GerenciadorHotel.Application.Models;
using MediatR;

namespace GerenciadorHotel.Application.Interfaces.Product.Commands.DeleteProduct;

public class DeleteProductCommand : IRequest<ResultViewModel>
{
    public int Id { get; set; }

    public DeleteProductCommand(int id)
    {
        Id = id;
    }
}