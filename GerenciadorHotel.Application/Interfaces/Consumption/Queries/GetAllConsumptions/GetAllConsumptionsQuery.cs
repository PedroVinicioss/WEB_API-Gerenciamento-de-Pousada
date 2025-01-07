using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.ViewModels;
using MediatR;

namespace GerenciadorHotel.Application.Interfaces.Consumption.Queries.GetAllConsumptions;

public class GetAllConsumptionsQuery : IRequest<ResultViewModel<List<ConsumptionViewModel>>>
{
    public GetAllConsumptionsQuery(string search)
    {
        Search = search;
    }

    public string Search { get; set; }
}