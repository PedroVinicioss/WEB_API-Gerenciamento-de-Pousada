using GerenciadorHotel.Core.Entities;
using GerenciadorHotel.Core.Enums;

namespace GerenciadorHotel.Application.Models.InputModels;

public class UpdateUserInputModel 
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; private set; }
    public string Cpf { get; private set; }
    public string Rg { get; private set; }
    // Personal Info
    public string? Phone { get; set; }
    public string MobilePhone { get; set; }
    public string? Profession { get; set; }

    
    // Address
    public string PostalCode { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string Address { get; set; }
    public string Neighborhood { get; set; }
    public int Number { get; set; }
    public string? AddressComplement { get; set; }
    
    public DateTime BirthDate { get; set; }
    public BiologicalSexEnum BiologicalSex { get; set; }
    
    public User ToEntity()
        => new(FullName, Email, Password, Phone, MobilePhone, Cpf, Rg, Profession, PostalCode, City, State, Country, Address, Neighborhood, Number, AddressComplement, BirthDate, BiologicalSex);
}