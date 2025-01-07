using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.ViewModels;
using MediatR;

namespace GerenciadorHotel.Application.Interfaces.Cash.Queries.GetCashById;

public class GetCashByIdQuery : IRequest<ResultViewModel<CashViewModel>>
{
    public GetCashByIdQuery(int id)
    {
        Id = Id;
    }

    public int Id { get; set; }
}