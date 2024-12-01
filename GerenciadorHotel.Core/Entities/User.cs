﻿using GerenciadorHotel.Core.Enums;

namespace GerenciadorHotel.Core.Entities;

public class User : BaseEntity
{
    protected User() { }

    public User(string fullName, string email, string hashPassword, string phone, string mobilePhone, string cpf, string rg, string profession, string postalCode, string city, string state, string country, string address, string neighborhood, int number, string addressComplement, DateTime birthDate, BiologicalSexEnum biologicalSex, bool active, RoleEnum role)
        : base()
    {
        FullName = fullName;
        Email = email;
        HashPassword = hashPassword;
        Phone = phone;
        MobilePhone = mobilePhone;
        Cpf = cpf;
        Rg = rg;
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
        Active = true;
        Role = role;
        
        Reservations = [];
        Partners = [];
    }
    
    public string FullName { get; private set; }
    public string Email { get; private set; }
    public string HashPassword { get; private set; }
    public string Phone { get; private set; }
    public string MobilePhone { get; private set; }
    public string Cpf { get; private set; }
    public string Rg { get; private set; }
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
    
    public bool Active { get; private set; }
    public RoleEnum Role { get; private set; }
    
    public List<Reservation> Reservations { get; private set; }
    public List<Partner> Partners { get; private set; }
    
    
    public void Update(string fullName, string email, string phone, string mobilePhone, string cpf, string rg, string profession, string postalCode, string city, string state, string country, string address, string neighborhood, int number, string addressComplement, DateTime birthDate, BiologicalSexEnum biologicalSex, bool active, RoleEnum role)
    {
        FullName = fullName;
        Email = email;
        Phone = phone;
        MobilePhone = mobilePhone;
        Cpf = cpf;
        Rg = rg;
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
        Active = active;
        Role = role;
    }
}