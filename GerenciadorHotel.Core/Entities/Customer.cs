using GerenciadorHotel.Core.Enums;

namespace GerenciadorHotel.Core.Entities;

public class Customer : User
{
    public Customer(string fullName, string email, string hashPassword, string phone, string mobilePhone, string document, string profession, string postalCode, string city, string state, string country, string address, string neighborhood, int number, string addressComplement, DateTime birthDate, BiologicalSexEnum biologicalSex)
        : base(fullName, email, hashPassword, phone, mobilePhone, document, birthDate, biologicalSex, RoleEnum.Customer)
    {
        Profession = profession;
        PostalCode = postalCode;
        City = city;
        State = state;
        Country = country;
        Address = address;
        Neighborhood = neighborhood;
        Number = number;
        AddressComplement = addressComplement;
        Reservations = new List<Reservation>();
    }
    public string Profession { get; private set; }
    public string PostalCode { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }
    public string Address { get; private set; }
    public string Neighborhood { get; private set; }
    public int Number { get; private set; }
    public string AddressComplement { get; private set; }
    public List<Reservation> Reservations { get; private set; }


    public void AddReservation(Reservation reservation)
    {
        Reservations.Add(reservation);
    }
    
}
