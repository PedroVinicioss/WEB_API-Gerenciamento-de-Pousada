using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Core.Enums;
using MediatR;

namespace GerenciadorHotel.Application.Interfaces.Customers.Commands.UpdateCustomer;

public class UpdateCustomerCommand : IRequest<ResultViewModel>
{
    public UpdateCustomerCommand(int id, string fullName, string email, string hashPassword, string phone, string mobilePhone, string document, string profession, string postalCode, string city, string state, string country, string address, string neighborhood, int number, string addressComplement, DateTime birthDate, BiologicalSexEnum biologicalSex, bool active)
    {
        Id = id;
        FullName = fullName;
        Email = email;
        HashPassword = hashPassword;
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

    public int Id { get; set; }
    public string FullName { get; private set; }
    public string Email { get; private set; }
    public string HashPassword { get; private set; }
    public string Phone { get; private set; }
    public string MobilePhone { get; private set; }
    public string Document { get; private set; }
    public string Profession { get; private set; }
    
    public string PostalCode { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }
    public string Address { get; private set; }
    public string Neighborhood { get; private set; }
    public int Number { get; private set; }
    public string AddressComplement { get; private set; }
    
    public DateTime BirthDate { get; private set; }
    public BiologicalSexEnum BiologicalSex { get; private set; }
    
    
    public Core.Entities.Customer ToEntity()
        => new Core.Entities.Customer(FullName, Email, HashPassword, Phone, MobilePhone, Document, Profession, PostalCode, City, State, Country, Address, Neighborhood, Number, AddressComplement, BirthDate, BiologicalSex);
}