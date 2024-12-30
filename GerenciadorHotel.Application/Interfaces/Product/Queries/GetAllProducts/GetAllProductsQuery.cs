using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.ViewModels;
using MediatR;

namespace GerenciadorHotel.Application.Interfaces.Product.Queries.GetAllProducts;

public class GetAllProductsQuery : IRequest<ResultViewModel<List<ProductViewModel>>>
{
    public GetAllProductsQuery(string search)
    {
        Search = search;
    }

    public string Search { get; set; }
}