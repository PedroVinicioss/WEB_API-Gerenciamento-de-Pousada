using GerenciadorHotel.Application.Models;
using MediatR;

namespace GerenciadorHotel.Application.Interfaces.Calendary.Commands.GenerateCalendaryForRoom;

public class GenerateCalendaryForRoomCommand : IRequest<ResultViewModel>
{
    public GenerateCalendaryForRoomCommand(int idRoom, DateTime startDate, DateTime endDate, int idAdmin)
    {
        IdRoom = idRoom;
        StartDate = startDate;
        EndDate = endDate;
        IdAdmin = idAdmin;
    }

    public int IdRoom { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int IdAdmin { get; set; }
}