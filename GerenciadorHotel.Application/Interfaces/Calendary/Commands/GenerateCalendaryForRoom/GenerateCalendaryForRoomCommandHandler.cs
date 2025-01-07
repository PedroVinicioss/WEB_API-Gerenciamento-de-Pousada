using GerenciadorHotel.Application.Interfaces.Cash.Commands.CreateCash;
using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Infrastructure.Persistence;
using MediatR;

namespace GerenciadorHotel.Application.Interfaces.Calendary.Commands.GenerateCalendaryForRoom;

public class GenerateCalendaryForRoomCommandHandler : IRequestHandler<GenerateCalendaryForRoomCommand, ResultViewModel>
{
    private readonly AppDbContext _context;
    private readonly IMediator _mediator;

    public GenerateCalendaryForRoomCommandHandler(AppDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<ResultViewModel> Handle(GenerateCalendaryForRoomCommand request, CancellationToken cancellationToken)
    {
        var existingDates = _context.Calendars
            .Where(c => c.IdRoom == request.IdRoom && c.Date >= request.StartDate && c.Date <= request.EndDate)
            .Select(c => c.Date)
            .ToHashSet();

        var newDates = new List<Core.Entities.Calendary>();

        for (var date = request.StartDate.Date; date <= request.EndDate.Date; date = date.AddDays(1))
        {
            if (!existingDates.Contains(date))
            {
                newDates.Add(new Core.Entities.Calendary(request.IdRoom, date, true));
            }
        }
        
        //pega os meses inseridos para criar os caixas
        var months = newDates.Select(d => d.Date.ToString("MM/yyyy")).Distinct();
        foreach (var monthdate in months)
        {
            //verifica se já existe um caixa para o mês e se não existir cria um novo com o createcashinputmodel
            var openingDate = DateTime.Parse($"01/{monthdate}");
            var closingDate = DateTime.Parse($"01/{monthdate}").AddMonths(1).AddDays(-1);
            var month = monthdate;
            var idAdmin = request.IdAdmin;
            await _mediator.Send(new CreateCashCommand(openingDate, closingDate, month, idAdmin), cancellationToken);
        }

        _context.Calendars.AddRange(newDates);
        await _context.SaveChangesAsync(cancellationToken);
        
        return ResultViewModel.Success();
    }

}