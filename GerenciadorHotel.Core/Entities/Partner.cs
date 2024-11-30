using GerenciadorHotel.Core.Enums;

namespace GerenciadorHotel.Core.Entities;

public class Partner : BaseEntity
{
    protected Partner() { }
    
    public Partner(string fullName, string email, string cpf, string rg, string mobilePhone, DateTime birthDate, BiologicalSexEnum biologicalSex, string profession, int idCustomer, User customer)
        : base()
    {
        FullName = fullName;
        Email = email;
        Cpf = cpf;
        Rg = rg;
        MobilePhone = mobilePhone;
        BirthDate = birthDate;
        BiologicalSex = biologicalSex;
        Profession = profession;
        IdCustomer = idCustomer;
    }

    public string FullName { get; private set; }
    public string Email { get; private set; }
    public string Cpf { get; private set; }
    public string Rg { get; private set; }
    public string MobilePhone { get; private set; }
    
    public DateTime BirthDate { get; private set; }
    public BiologicalSexEnum BiologicalSex { get; private set; }    
    
    public string Profession { get; private set; }

    public int IdCustomer { get; private set; }
    public User Customer { get; private set; }
    
    public void Update (string fullName, string email, string cpf, string rg, string mobilePhone, DateTime birthDate, BiologicalSexEnum biologicalSex, string profession)
    {
        FullName = fullName;
        Email = email;
        Cpf = cpf;
        Rg = rg;
        MobilePhone = mobilePhone;
        BirthDate = birthDate;
        BiologicalSex = biologicalSex;
        Profession = profession;
    }
}