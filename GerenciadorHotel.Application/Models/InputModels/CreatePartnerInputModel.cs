﻿namespace GerenciadorHotel.Application.Models.InputModels;

public class CreatePartnerInputModel
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string? Phone { get; set; }
    public string MobilePhone { get; set; }
    public string Cpf { get; set; }
    public string Rg { get; set; }
    public string? Profession { get; set; }
    public DateTime BirthDate { get; set; }
    public int BiologicalSex { get; set; }
    public string PostalCode { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string Address { get; set; }
    public string Neighborhood { get; set; }
    public int Number { get; set; }
    public string? AddressComplement { get; set; }
}