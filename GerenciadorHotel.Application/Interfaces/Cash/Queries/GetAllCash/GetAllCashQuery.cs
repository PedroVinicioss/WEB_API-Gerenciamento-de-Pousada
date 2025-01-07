using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.ViewModels;
using MediatR;

namespace GerenciadorHotel.Application.Interfaces.Cash.Queries.GetAllCash;

public class GetAllCashQuery : IRequest<ResultViewModel<List<CashViewModel>>>
{
    public GetAllCashQuery(string search)
    {
        Search = search;
    }

    public string Search { get; set; }
}