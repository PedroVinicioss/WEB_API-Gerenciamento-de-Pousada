using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.InputModels;
using GerenciadorHotel.Application.Models.ViewModels;
using GerenciadorHotel.Core.Entities;
using GerenciadorHotel.Infrastructure.Persistence;

namespace GerenciadorHotel.Application.Services;

public class UserService : IUserService
{
    private AppDbContext _context;
    
    public UserService(AppDbContext context)
    {
        _context = context;
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
        var user = _context.Users.FirstOrDefault(u => u.Id == id);
        if(user is null)
            return ResultViewModel<UserViewModel>.Error("Usuário não encontrado");
        
        var model = UserViewModel.FromEntity(user);
        
        return ResultViewModel<UserViewModel>.Success(model);
    }

    public ResultViewModel<int> Insert(CreateUserInputModel model)
    {
        var user = model.ToEntity();
        
        _context.Users.Add(user);
        _context.SaveChanges();
        
        return ResultViewModel<int>.Success(user.Id);
    }

    public ResultViewModel Update(UpdateUserInputModel model)
    {
        var user = _context.Users.SingleOrDefault(u => u.Id == model.Id);
        if(user is null)
            return ResultViewModel.Error("Usuário não encontrado");
        
        user.Update(model.ToEntity());
        
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
}