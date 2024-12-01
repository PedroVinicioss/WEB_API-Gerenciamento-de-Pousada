namespace GerenciadorHotel.Application.Models.InputModels;

public class CreateReservationInputModel
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int IdRoom { get; set; }
    public int IdCustomer { get; set; }
    public int IdCalendary { get; set; }
}