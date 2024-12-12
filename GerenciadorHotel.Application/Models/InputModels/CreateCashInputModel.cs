using GerenciadorHotel.Core.Entities;

namespace GerenciadorHotel.Application.Models.InputModels;

public class CreateCashInputModel
{
    public CreateCashInputModel() { }
    
    public CreateCashInputModel(DateTime openingDate, DateTime closingDate, string month, int idAdmin)
    {
        OpeningDate = openingDate;
        ClosingDate = closingDate;
        Month = month;
        IdAdmin = idAdmin;
    }

    public DateTime OpeningDate { get;  set; }
    public DateTime ClosingDate { get;  set; }
    public string Month { get;  set; }
    public int IdAdmin { get;  set; }
    
    public Cash ToEntity()
    {
        return new Cash(OpeningDate, ClosingDate, 0, 0, 0, Month, IdAdmin);
    }
}