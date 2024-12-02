using GerenciadorHotel.Core.Entities;
using GerenciadorHotel.Infrastructure.Persistence;

namespace GerenciadorHotel.Application.Services;

public class CalendaryService
{
    private readonly AppDbContext _context;
    
    public CalendaryService(AppDbContext context)
    {
        _context = context;
    }
    
    public void GenerateCalendaryForRoom(int idRoom, DateTime startDate, DateTime endDate)
    {
        var existingDates = _context.Calendars
            .Where(c => c.IdRoom == idRoom && c.Date >= startDate && c.Date <= endDate)
            .Select(c => c.Date)
            .ToHashSet();

        var newDates = new List<Calendary>();

        for (var date = startDate.Date; date <= endDate.Date; date = date.AddDays(1))
        {
            if (!existingDates.Contains(date))
            {
                newDates.Add(new Calendary(idRoom, date, true));
            }
        }

        _context.Calendars.AddRange(newDates);
        _context.SaveChanges();
    }
    
    public IEnumerable<Calendary> GetCalendaryForRoom(int idRoom)
    {
        return _context.Calendars
            .Where(c => c.IdRoom == idRoom)
            .ToList();
    }
}