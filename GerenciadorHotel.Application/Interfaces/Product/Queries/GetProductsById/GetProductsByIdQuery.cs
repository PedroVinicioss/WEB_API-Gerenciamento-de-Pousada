using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.ViewModels;
using MediatR;

namespace GerenciadorHotel.Application.Interfaces.Product.Queries.GetProductsById;

public class GetProductsByIdQuery : IRequest<ResultViewModel<ProductViewModel>>
{
    public GetProductsByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}