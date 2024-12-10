using GerenciadorHotel.Infrastructure.Persistence;

namespace GerenciadorHotel.Application.Interfaces.Calendary.Services;

public class CalendaryService : ICalendaryService
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

        var newDates = new List<Core.Entities.Calendary>();

        for (var date = startDate.Date; date <= endDate.Date; date = date.AddDays(1))
        {
            if (!existingDates.Contains(date))
            {
                newDates.Add(new Core.Entities.Calendary(idRoom, date, true));
            }
        }

        _context.Calendars.AddRange(newDates);
        _context.SaveChanges();
    }
    
    public IEnumerable<Core.Entities.Calendary> GetCalendaryForRoom(int idRoom)
    {
        return _context.Calendars
            .Where(c => c.IdRoom == idRoom)
            .ToList();
    }
}