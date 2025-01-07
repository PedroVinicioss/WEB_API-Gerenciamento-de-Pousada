using GerenciadorHotel.Application.Models;
using MediatR;

namespace GerenciadorHotel.Application.Interfaces.Cash.Commands.CreateCash;

public class CreateCashCommand : IRequest<ResultViewModel<int>>
{
    public CreateCashCommand(DateTime openingDate, DateTime closingDate, string month, int idAdmin)
    {
        OpeningDate = openingDate;
        ClosingDate = closingDate;
        Month = month;
        IdAdmin = idAdmin;
    }

    public DateTime OpeningDate { get; set; }
    public DateTime ClosingDate { get; set; }
    public string Month { get; set; }
    public int IdAdmin { get; set; }

    public Core.Entities.Cash ToEntity()
        => new (OpeningDate, ClosingDate, 0, 0, 0, Month, IdAdmin);
}