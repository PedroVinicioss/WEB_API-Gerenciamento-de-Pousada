using GerenciadorHotel.Core.Entities;

namespace GerenciadorHotel.Application.Services;

public interface ICalendaryService
{
    void GenerateCalendaryForRoom(int idRoom, DateTime startDate, DateTime endDate);
    IEnumerable<Calendary> GetCalendaryForRoom(int idRoom);
}