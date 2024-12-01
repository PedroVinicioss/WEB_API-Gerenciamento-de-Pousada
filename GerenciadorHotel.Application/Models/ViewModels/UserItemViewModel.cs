using GerenciadorHotel.Core.Entities;

namespace GerenciadorHotel.Application.Models.ViewModels;

public class UserItemViewModel
{
    public UserItemViewModel(int id, string name, string email, string cpf, string role, DateTime createdData)
    {
        Id = id;
        Name = name;
        Email = email;
        Cpf = cpf;
        Role = role;
        CreatedData = createdData;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Cpf { get; set; }
    public string Role { get; set; }
    public DateTime CreatedData { get; set; }
    
    public static UserItemViewModel FromEntity(User entity)
        => new(entity.Id, entity.FullName, entity.Email, entity.Cpf, entity.Role.ToString(), entity.CreatedAt);
}