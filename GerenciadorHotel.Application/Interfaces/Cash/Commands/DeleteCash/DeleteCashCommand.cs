using GerenciadorHotel.Application.Models;
using MediatR;

namespace GerenciadorHotel.Application.Interfaces.Cash.Commands.DeleteCash;

public class DeleteCashCommand : IRequest<ResultViewModel>
{
    public DeleteCashCommand(int id)
    {
        Id = Id;
    }

    public int Id { get; set; }
}