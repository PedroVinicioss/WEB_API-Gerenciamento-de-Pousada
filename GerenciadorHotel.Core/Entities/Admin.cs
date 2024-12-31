using GerenciadorHotel.Core.Enums;

namespace GerenciadorHotel.Core.Entities;

public class Admin : User
{
    public Admin(string fullName, string email, string hashPassword, string phone, string mobilePhone, string document, DateTime birthDate, BiologicalSexEnum biologicalSex) 
        : base(fullName, email, hashPassword, phone, mobilePhone, document, birthDate, biologicalSex, RoleEnum.Admin)
    {
        Cashes = new List<Cash>();
    }

    public List<Cash> Cashes { get; private set; }
    
    public void AddCash(Cash cash)
    {
        Cashes.Add(cash);
    }
}