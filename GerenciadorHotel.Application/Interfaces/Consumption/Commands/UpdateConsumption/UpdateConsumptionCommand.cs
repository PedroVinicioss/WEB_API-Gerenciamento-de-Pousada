using GerenciadorHotel.Application.Models;
using MediatR;

namespace GerenciadorHotel.Application.Interfaces.Consumption.Commands.UpdateConsumption
{
    public class UpdateConsumptionCommand : IRequest<ResultViewModel>
    {
        public UpdateConsumptionCommand(int id, int idReservation, int idProduct, int quantity, DateTime consumptionDate)
        {
            Id = id;
            IdReservation = idReservation;
            IdProduct = idProduct;
            Quantity = quantity;
            ConsumptionDate = consumptionDate;
        }
        public int Id { get; set; }
        public int IdReservation { get; private set; }
        public int IdProduct { get; set; }
        public int Quantity { get; set; }
        public DateTime ConsumptionDate { get; set; }

        public Core.Entities.Consumption ToEntity(decimal value)
            => new(IdReservation, IdProduct, Quantity, value, ConsumptionDate);
    }
}