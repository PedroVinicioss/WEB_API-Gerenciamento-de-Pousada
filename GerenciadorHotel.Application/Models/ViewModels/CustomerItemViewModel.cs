using GerenciadorHotel.Core.Entities;

namespace GerenciadorHotel.Application.Models.ViewModels;

public class CustomerItemViewModel
{
    public CustomerItemViewModel(int id, string name, string email, string document, string role, DateTime createdData)
    {
        Id = id;
        Name = name;
        Email = email;
        Document = document;
        Role = role;
        CreatedData = createdData;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Document { get; set; }
    public string Role { get; set; }
    public DateTime CreatedData { get; set; }
    
    public static CustomerItemViewModel FromEntity(Customer? entity)
        => new(entity.Id, entity.FullName, entity.Email, entity.Document, entity.Role.ToString(), entity.CreatedAt);
}