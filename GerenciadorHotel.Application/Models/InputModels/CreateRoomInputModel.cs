namespace GerenciadorHotel.Application.Models.InputModels;

public class CreateRoomInputModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal DaylyValue { get; set; }
    public int Capacity { get; set; }
    public int Type { get; set; }
}