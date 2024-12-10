namespace GerenciadorHotel.Application.Interfaces.Calendary.Services;

public interface ICalendaryService
{
    void GenerateCalendaryForRoom(int idRoom, DateTime startDate, DateTime endDate);
    IEnumerable<Core.Entities.Calendary> GetCalendaryForRoom(int idRoom);
}