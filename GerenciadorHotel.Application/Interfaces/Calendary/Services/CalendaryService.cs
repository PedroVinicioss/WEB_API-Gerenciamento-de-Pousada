using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.InputModels;
using GerenciadorHotel.Infrastructure.Persistence;

namespace GerenciadorHotel.Application.Interfaces.Calendary.Services;

public class CalendaryService : ICalendaryService
{
    private readonly AppDbContext _context;
    
    public CalendaryService(AppDbContext context)
    {
        _context = context;
    }
    
    public ResultViewModel GenerateCalendaryForRoom(int idRoom, DateTime startDate, DateTime endDate)
    {
        var existingDates = _context.Calendars
            .Where(c => c.IdRoom == idRoom && c.Date >= startDate && c.Date <= endDate)
            .Select(c => c.Date)
            .ToHashSet();

        var newDates = new List<Core.Entities.Calendary>();

        for (var date = startDate.Date; date <= endDate.Date; date = date.AddDays(1))
        {
            if (!existingDates.Contains(date))
            {
                newDates.Add(new Core.Entities.Calendary(idRoom, date, true));
            }
        }
        
        //pega os meses inseridos para criar os caixas
        var months = newDates.Select(d => d.Date.ToString("MM/yyyy")).Distinct();
        foreach (var month in months)
        {
            //verifica se já existe um caixa para o mês e se não existir cria um novo com o createcashinputmodel
            var cash = new CreateCashInputModel
            {
                OpeningDate = DateTime.Parse($"01/{month}"),
                ClosingDate = DateTime.Parse($"01/{month}").AddMonths(1).AddDays(-1),
                Month = month,
                IdAdmin = 1
            };
            
            _context.Cash.Add(cash.ToEntity());
        }

        _context.Calendars.AddRange(newDates);
        _context.SaveChanges();
        
        return ResultViewModel.Success();
    }


    public IEnumerable<Core.Entities.Calendary> GetCalendaryForRoom(int idRoom)
    {
        return _context.Calendars
            .Where(c => c.IdRoom == idRoom)
            .ToList();
    }
}