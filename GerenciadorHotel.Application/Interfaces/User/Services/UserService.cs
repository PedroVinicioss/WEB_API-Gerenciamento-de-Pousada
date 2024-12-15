using System.Security.Cryptography;
using System.Text;
using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.InputModels;
using GerenciadorHotel.Application.Models.ViewModels;
using GerenciadorHotel.Infrastructure.Persistence;

namespace GerenciadorHotel.Application.Interfaces.User.Services;

public class UserService : IUserService
{
    private AppDbContext _context;
    
    public UserService(AppDbContext context)
    {
        _context = context;
    }
    
    private string DoHash(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            var builder = new StringBuilder();
            foreach (var b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }
    }   
    
    public ResultViewModel<List<UserItemViewModel>> GetAll(string search = "")
    {
        var users = _context.Users
            .Where(u => !u.IsDeleted && (search == "" || u.FullName.Contains(search) || u.Email.Contains(search) || u.Phone.Contains(search) || u.MobilePhone.Contains(search) || u.Cpf.Contains(search) || u.Rg.Contains(search) || u.Profession.Contains(search)))
            .Select(u => UserItemViewModel.FromEntity(u))
            .ToList();
        
        return ResultViewModel<List<UserItemViewModel>>.Success(users);
    }

    public ResultViewModel<UserViewModel> GetById(int id)
    {
        var user = _context.Users.SingleOrDefault(u => u.Id == id);
        if(user is null)
            return ResultViewModel<UserViewModel>.Error("Usuário não encontrado");
        
        var model = UserViewModel.FromEntity(user);
        
        return ResultViewModel<UserViewModel>.Success(model);
    }

    public ResultViewModel<int> Insert(CreateUserInputModel model)
    {
                
        //verifica requisitos de senha
        if(model.Password.Length < 6)
            return ResultViewModel<int>.Error("A senha deve ter no mínimo 6 caracteres");
        
        if(!model.Password.Any(char.IsDigit))
            return ResultViewModel<int>.Error("A senha deve conter ao menos um número");
        
        if(!model.Password.Any(char.IsUpper))
            return ResultViewModel<int>.Error("A senha deve conter ao menos uma letra maiúscula");
        
        if(!model.Password.Any(char.IsLower))
            return ResultViewModel<int>.Error("A senha deve conter ao menos uma letra minúscula");
        
        model.Password = DoHash(model.Password);
        var user = model.ToEntity();
        
        //verificar se o email já existe
        var userExists = _context.Users.Any(u => u.Email == user.Email);
        if(userExists)
            return ResultViewModel<int>.Error("Email já cadastrado");
        
        //verificar se o cpf já existe
        userExists = _context.Users.Any(u => u.Cpf == user.Cpf);
        if(userExists)
            return ResultViewModel<int>.Error("CPF já cadastrado");
        
        //verificar se o rg já existe
        userExists = _context.Users.Any(u => u.Rg == user.Rg);
        if(userExists)
            return ResultViewModel<int>.Error("RG já cadastrado");
        
        _context.Users.Add(user);
        _context.SaveChanges();
        
        return ResultViewModel<int>.Success(user.Id);
    }

    public ResultViewModel Update(Core.Entities.User model)
    {
        var user = _context.Users.SingleOrDefault(u => u.Id == model.Id);
        if(user is null)
            return ResultViewModel.Error("Usuário não encontrado");
        
        user.Update(model);
        
        _context.Update(user);
        _context.SaveChanges();
        
        return ResultViewModel.Success();
    }

    public ResultViewModel Delete(int id)
    {
        var user = _context.Users.SingleOrDefault(u => u.Id == id);
        if(user is null)
            return ResultViewModel.Error("Usuário não encontrado");
        
        user.SetAsDelete();
        
        _context.Update(user);
        _context.SaveChanges();
        
        return ResultViewModel.Success();
    }
    
    public ResultViewModel<int> Authenticate(string email, string password)
    {
        password = DoHash(password);
        
        var user = _context.Users.SingleOrDefault(u => u.Email == email && u.HashPassword == password);
        if (user is null)
        {
            user = _context.Users.SingleOrDefault(u => u.Email == email);
            if (user is null)
                return ResultViewModel<int>.Error("Usuário não encontrado");
            
            return ResultViewModel<int>.Error("Senha inválida");
        }
        
        return ResultViewModel<int>.Success(user.Id);
    }
}