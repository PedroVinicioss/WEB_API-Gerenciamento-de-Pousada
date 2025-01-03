using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHotel.Application.Interfaces.Consumption.Commands.UpdateConsumption
{
    public class UpdateConsumptionCommandHandler : IRequestHandler<UpdateConsumptionCommand, ResultViewModel>
    {
        private readonly AppDbContext _context;

        public UpdateConsumptionCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel> Handle(UpdateConsumptionCommand request, CancellationToken cancellationToken)
        {
            var consumption = await _context.Consumptions.SingleOrDefaultAsync(c => c.Id == request.Id);
            if(consumption is null)
                return ResultViewModel.Error("Consumo não encontrado");

            var product = await _context.Products.SingleOrDefaultAsync(p => p.Id == request.IdProduct);
            if(product is null)
                return ResultViewModel.Error("Produto não encontrado");

            var room = await _context.Reservations.SingleOrDefaultAsync(r => r.Id == request.IdReservation);
            if(room is null)
                return ResultViewModel.Error("Quarto não encontrado");

            var value = product.Price * request.Quantity;
            var consumptionModel = request.ToEntity(value);

            consumption.Update(consumptionModel);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}