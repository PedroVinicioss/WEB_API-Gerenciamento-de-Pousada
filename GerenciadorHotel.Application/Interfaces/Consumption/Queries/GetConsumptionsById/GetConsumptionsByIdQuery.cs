using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.ViewModels;
using MediatR;

namespace GerenciadorHotel.Application.Interfaces.Consumption.Queries.GetConsumptionsById;

public class GetConsumptionsByIdQuery : IRequest<ResultViewModel<ConsumptionViewModel>>
{
    public GetConsumptionsByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}