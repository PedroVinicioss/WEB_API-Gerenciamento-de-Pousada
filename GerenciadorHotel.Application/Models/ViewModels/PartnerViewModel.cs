using GerenciadorHotel.Core.Entities;

namespace GerenciadorHotel.Application.Models.ViewModels;

public class PartnerViewModel
{
    public PartnerViewModel(int id, string fullName, string email, string cpf, string rg, string mobilePhone, DateTime birthDate, string sex, string profession, int idCustomer, string customerName)
    {
        Id = id;
        FullName = fullName;
        Email = email;
        Cpf = cpf;
        Rg = rg;
        MobilePhone = mobilePhone;
        BirthDate = birthDate;
        Sex = sex;
        Profession = profession;
        IdCustomer = idCustomer;
        CustomerName = customerName;
    }

    public int Id { get;  set; }
    public string FullName { get;  set; }
    public string Email { get;  set; }
    public string Cpf { get;  set; }
    public string Rg { get;  set; }
    public string MobilePhone { get;  set; }
    public DateTime BirthDate { get;  set; }
    public string Sex { get;  set; }    
    public string Profession { get;  set; }
    public int IdCustomer { get;  set; }
    public string CustomerName { get;  set; }
    
    public static PartnerViewModel FromEntity(Partner entity)
        => new(entity.Id, entity.FullName, entity.Email, entity.Cpf, entity.Rg, entity.MobilePhone, entity.BirthDate, entity.BiologicalSex.ToString(), entity.Profession, entity.IdCustomer, entity.Customer.FullName);
}