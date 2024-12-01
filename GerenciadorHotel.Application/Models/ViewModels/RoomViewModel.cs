using GerenciadorHotel.Core.Entities;

namespace GerenciadorHotel.Application.Models.ViewModels;

public class RoomViewModel
{
    public RoomViewModel(int id, string name, string description, decimal daylyValue, int capacity, string type, List<Reservation> reservations)
    {
        Id = id;
        Name = name;
        Description = description;
        DaylyValue = daylyValue;
        Capacity = capacity;
        Type = type;
        Reservations = reservations.Select(ReservationViewModel.FromEntity).ToList();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal DaylyValue { get; set; }
    public int Capacity { get; set; }
    public string Type { get; set; }
    public List<ReservationViewModel> Reservations { get; set; }
    
    public static RoomViewModel FromEntity(Room entity)
        => new(entity.Id, entity.RoomName, entity.Description, entity.DaylyValue, entity.Capacity, entity.Type.ToString(), entity.Reservations);
}