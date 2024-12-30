using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.ViewModels;
using MediatR;

namespace GerenciadorHotel.Application.Interfaces.Product.Queries.GetProductsById;

public class GetProductsById : IRequest<ResultViewModel<ProductViewModel>>
{
    public GetProductsById(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}