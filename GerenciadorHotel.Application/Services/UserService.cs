using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.ViewModels;
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
            .Where(u => u.Name.Contains(search))
            .Select(u => new UserItemViewModel(u.Id, u.Name, u.Email))
            .ToList();
        
        return ResultViewModel<List<UserItemViewModel>>.Success(users);
    }
}