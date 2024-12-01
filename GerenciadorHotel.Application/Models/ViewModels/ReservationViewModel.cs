using GerenciadorHotel.Core.Entities;

namespace GerenciadorHotel.Application.Models.ViewModels;

public class ReservationViewModel
{
    public ReservationViewModel(int id, DateTime startDate, DateTime endDate, decimal totalCost, string customerName, int idCustomer, string roomName, int idRoom)
    {
        Id = id;
        StartDate = startDate;
        EndDate = endDate;
        TotalCost = totalCost;
        CustomerName = customerName;
        IdCustomer = idCustomer;
        RoomName = roomName;
        IdRoom = idRoom;
    }

    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal TotalCost { get; set; }
    public string CustomerName { get; set; }
    public int IdCustomer { get; set; }
    public string RoomName { get; set; }
    public int IdRoom { get; set; }

    public static ReservationViewModel FromEntity(Reservation entity)
        => new(entity.Id, entity.StartDate, entity.EndDate, entity.TotalCost, entity.Customer.FullName, entity.IdCustomer, entity.Room.RoomName, entity.IdRoom);
}