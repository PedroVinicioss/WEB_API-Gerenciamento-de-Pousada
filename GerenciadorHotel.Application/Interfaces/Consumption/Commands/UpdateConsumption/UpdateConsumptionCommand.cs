using GerenciadorHotel.Application.Models;
using MediatR;

namespace GerenciadorHotel.Application.Interfaces.Consumption.Commands.UpdateConsumption;

public class UpdateConsumptionCommand : IRequest<ResultViewModel>
{
    public UpdateConsumptionCommand(int id, int idReservation, int idProduct, int quantity, decimal value, DateTime consumptionDate)
    {
        Id = id;
        IdReservation = idReservation;
        IdProduct = idProduct;
        Quantity = quantity;
        Value = value;
        ConsumptionDate = consumptionDate;
    }

    public int Id { get; set; }
    public int IdReservation { get; private set; }
    public int IdProduct { get; private set; }
    public int Quantity { get; private set; }
    public decimal Value { get; private set; }
    public DateTime ConsumptionDate { get; private set; }
    
    public Core.Entities.Consumption ToEntity(decimal value)
    {
        return new (IdReservation, IdProduct, Quantity, Value, ConsumptionDate);
    }
}