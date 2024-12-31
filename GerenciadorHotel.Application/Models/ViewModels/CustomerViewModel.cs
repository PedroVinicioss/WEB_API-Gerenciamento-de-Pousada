using System.Reflection.Metadata;
using GerenciadorHotel.Core.Entities;

namespace GerenciadorHotel.Application.Models.ViewModels;

public class CustomerViewModel
{
    public CustomerViewModel(int id, string fullName, string email, string phone, string mobilePhone, string document, string profession, string postalCode, string city, string state, string country, string address, string neighborhood, int number, string addressComplement, DateTime birthDate, string sex, string role, List<Reservation> reservations)
    {
        Id = id;
        FullName = fullName;
        Email = email;
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
        Sex = sex;
        Role = role;
        Reservations = reservations?.Select(ReservationViewModel.FromEntity)
            .Where(r => r.IdCustomer == id)
            .ToList() ?? new List<ReservationViewModel>();
    }
    

    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string MobilePhone { get; set; }
    public string Document { get; set; }
    public string Profession { get; set; }

    // Endereço
    public string PostalCode { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string Address { get; set; }
    public string Neighborhood { get; set; }
    public int Number { get; set; }
    public string AddressComplement { get; set; }
    public DateTime BirthDate { get; set; }
    public string Sex { get; set; }
    public string Role { get; set; }
    public List<ReservationViewModel> Reservations { get; set; }
    
    public static CustomerViewModel FromEntity(Customer entity)
        => new(entity.Id, entity.FullName, entity.Email, entity.Phone, entity.MobilePhone, entity.Document, entity.Profession, entity.PostalCode, entity.City, entity.State, entity.Country, entity.Address, entity.Neighborhood, entity.Number, entity.AddressComplement, entity.BirthDate, entity.BiologicalSex.ToString(), entity.Role.ToString(), entity.Reservations);
}