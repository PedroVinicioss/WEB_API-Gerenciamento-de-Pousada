using GerenciadorHotel.Application.Models;
using MediatR;

namespace GerenciadorHotel.Application.Interfaces.Cash.Commands.UpdateCash;

public class UpdateCashCommand : IRequest<ResultViewModel>
{
    public UpdateCashCommand(int id, DateTime openingDate, DateTime closingDate, string month, int idAdmin)
    {
        Id = id;
        OpeningDate = openingDate;
        ClosingDate = closingDate;
        Month = month;
        IdAdmin = idAdmin;
    }
    public int Id { get; set; }
    public DateTime OpeningDate { get; set; }
    public DateTime ClosingDate { get; set; }
    public string Month { get; set; }
    public int IdAdmin { get; set; }
    
    public Core.Entities.Cash ToEntity()
        => new (OpeningDate, ClosingDate, 0, 0, 0, Month, IdAdmin);
}