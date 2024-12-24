using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Core.Enums;
using MediatR;

namespace GerenciadorHotel.Application.Interfaces.User.Commands.UpdateUser;

public class UpdateUserCommand : IRequest<ResultViewModel>
{
    public int Id { get; set; }
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
    
    public Core.Entities.User ToEntity()
        => new Core.Entities.User(FullName, Email, HashPassword, Phone, MobilePhone, Cpf, Rg, Profession, PostalCode, City, State, Country, Address, Neighborhood, Number, AddressComplement, BirthDate, BiologicalSex);
}