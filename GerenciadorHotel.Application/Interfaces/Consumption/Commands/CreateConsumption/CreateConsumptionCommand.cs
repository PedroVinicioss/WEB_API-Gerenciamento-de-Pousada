using GerenciadorHotel.Application.Models;
using MediatR;

namespace GerenciadorHotel.Application.Interfaces.Consumption.Commands.CreateConsumption;

public class CreateConsumptionCommand : IRequest<ResultViewModel<int>>
{
    public CreateConsumptionCommand(int idProduct, int idReservation, int quantity, DateTime date)
    {
        IdProduct = idProduct;
        IdReservation = idReservation;
        Quantity = quantity;
        Date = date;
    }
    public int IdProduct { get; set; }
    public int IdReservation { get; set; }
    public int Quantity { get; set; }
    public DateTime Date { get; set; }

    public Core.Entities.Consumption ToEntity(decimal value)
    {
        return new (IdProduct, IdReservation, Quantity, value, Date);
    }
}