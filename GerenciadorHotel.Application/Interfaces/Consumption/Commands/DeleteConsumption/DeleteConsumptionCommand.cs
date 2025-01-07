using GerenciadorHotel.Application.Models;
using MediatR;

namespace GerenciadorHotel.Application.Interfaces.Consumption.Commands.DeleteConsumption;

public class DeleteConsumptionCommand : IRequest<ResultViewModel>
{
    public DeleteConsumptionCommand(int id)
    {
        Id = id;
    }
    
    public int Id { get; set; }
}