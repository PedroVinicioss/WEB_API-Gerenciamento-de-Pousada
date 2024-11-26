using GerenciadorHotel.Enums;

namespace GerenciadorHotel.Entities;

public class Room : BaseEntity
{
    protected Room() { }

    public Room(string roomName, string description, decimal daylyValue, int capacity, RoomTypeEnum type)
        : base()
    {
        RoomName = roomName;
        Description = description;
        IsAvailable = true;
        DaylyValue = daylyValue;
        Capacity = capacity;
        Type = type;
        
        Reservations = [];
        Calendars = [];
    }
    
    public string RoomName { get; private set; }
    public string Description { get; private set; }
    public bool IsAvailable { get; private set; }
    public decimal DaylyValue { get; private set; }
    public int Capacity { get; private set; }
    public RoomTypeEnum Type { get; private set; }

    public List<Reservation> Reservations { get; private set; }
    public List<Calendary> Calendars { get; private set; }
    
    public void Update(string roomName, string description, bool isAvailable, decimal daylyValue, int capacity, RoomTypeEnum type, Calendary calendary)
    {
        RoomName = roomName;
        Description = description;
        IsAvailable = isAvailable;
        DaylyValue = daylyValue;
        Capacity = capacity;
        Type = type;
        Calendars.Add(calendary);
    }
    
    public void SetAsAvailable()
    {
        IsAvailable = true;
    }
    
    public void SetAsUnavailable()
    {
        IsAvailable = false;
    }
}