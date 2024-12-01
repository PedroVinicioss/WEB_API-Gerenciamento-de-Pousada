namespace GerenciadorHotel.Application.Models.InputModels;

public class CreateConsuptionInputModel
{
    public int IdProduct { get; set; }
    public int IdReservation { get; set; }
    public int Quantity { get; set; }
    public DateTime Date { get; set; }
    public string? Observation { get; set; }
}