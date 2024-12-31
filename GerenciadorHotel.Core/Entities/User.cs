using GerenciadorHotel.Core.Enums;

namespace GerenciadorHotel.Core.Entities;

public class User : BaseEntity
{
    public User(string fullName, string email, string hashPassword, string phone, string mobilePhone, string document, DateTime birthDate, BiologicalSexEnum biologicalSex, RoleEnum role)
        : base()
    {
        FullName = fullName;
        Email = email;
        HashPassword = hashPassword;
        Phone = phone;
        MobilePhone = mobilePhone;
        Document = document;
        BirthDate = birthDate;
        BiologicalSex = biologicalSex;
        Role = role;
    }
    
    public string FullName { get; private set; }
    public string Email { get; private set; }
    public string HashPassword { get; private set; }
    public string Phone { get; private set; }
    public string MobilePhone { get; private set; }
    public string Document { get; private set; }
    public DateTime BirthDate { get; private set; }
    public BiologicalSexEnum BiologicalSex { get; private set; }
    public RoleEnum Role { get; private set; }
    
    public void Update(User user)
    {
        FullName = user.FullName;
        Email = user.Email;
        Phone = user.Phone;
        MobilePhone = user.MobilePhone;
        Document = user.Document;
        BirthDate = user.BirthDate;
        BiologicalSex = user.BiologicalSex;
    }
    
}