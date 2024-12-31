using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Core.Enums;
using MediatR;

namespace GerenciadorHotel.Application.Interfaces.Customers.Commands.CreateCustomer;

public class CreateCustomerCommand : IRequest<ResultViewModel<int>>
{
    //constructor
    public CreateCustomerCommand(string fullName, string email, string password, string phone, string mobilePhone, string document, string profession, string postalCode, string city, string state, string country, string address, string neighborhood, int number, string addressComplement, DateTime birthDate, BiologicalSexEnum biologicalSex)
    {
        FullName = fullName;
        Email = email;
        Password = password;
        Phone = phone;
        MobilePhone = mobilePhone;
        Document = document;
        Profession = profession;
        PostalCode = postalCode;
        City = city;
        State = state;
        Country = country;
        Address = address;
        Neighborhood = neighborhood;
        Number = number;
        AddressComplement = addressComplement;
        BirthDate = birthDate;
        BiologicalSex = biologicalSex;
    }
    
    // User Info
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    
    // Personal Info
    public string? Phone { get; set; }
    public string MobilePhone { get; set; }
    public string Document { get; set; }
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

    
    public Core.Entities.Customer ToEntity()
        => new(FullName, Email, Password, Phone, MobilePhone, Document, Profession, PostalCode, City, State, Country, Address, Neighborhood, Number, AddressComplement, BirthDate, BiologicalSex);
}