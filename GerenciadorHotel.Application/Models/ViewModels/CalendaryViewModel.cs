using GerenciadorHotel.Core.Entities;

namespace GerenciadorHotel.Application.Models.ViewModels;

public class CalendaryViewModel
{
    public CalendaryViewModel(int id, DateTime date, bool isAvailable, int? idReservation, int idRoom, string roomName, string customerName)
    {
        Id = id;
        Date = date;
        IsAvailable = isAvailable;
        IdReservation = idReservation;
        IdRoom = idRoom;
        RoomName = roomName;
        CustomerName = customerName;
    }
    
    public int Id { get; private set; }
    public DateTime Date { get; private set; }
    public bool IsAvailable { get; private set; }
    public int? IdReservation { get; private set; }
    public ReservationViewModel Reservation { get;  set; }
    public int IdRoom { get; private set; }
    public string RoomName { get; private set; }
    public string CustomerName { get; private set; }
    
    public static CalendaryViewModel FromEntity(Calendary entity)
        => new(entity.Id, entity.Date, entity.IsAvailable, entity.IdReservation, entity.IdRoom, entity.Room.RoomName, entity.Reservation.Customer.FullName);
}