using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.ViewModels;
using GerenciadorHotel.Core.Entities;
using GerenciadorHotel.Infrastructure.Persistence;

namespace GerenciadorHotel.Application.Services;

public class CashService : ICashService
{
    private AppDbContext _context;
    
    public CashService(AppDbContext context)
    {
        _context = context;
    }
    
    public ResultViewModel<List<CashViewModel>> GetAll()
    {
        var cash = _context.Cash
            .Where(c => !c.IsDeleted)
            .Select(c => CashViewModel.FromEntity(c))
            .ToList();
        
        return ResultViewModel<List<CashViewModel>>.Success(cash);
    }

    public ResultViewModel<CashViewModel> GetById(int id)
    {
        var cash = _context.Cash
            .SingleOrDefault(c => c.Id == id && !c.IsDeleted);
        if (cash == null)
            return ResultViewModel<CashViewModel>.Error("Caixa não encontrado");

        var model = CashViewModel.FromEntity(cash);
        
        return ResultViewModel<CashViewModel>.Success(model);
    }

    public ResultViewModel<CashViewModel> CreateCashForMonth(Cash model)
    {
        _context.Cash.Add(model);
        _context.SaveChanges();
        
        return ResultViewModel<CashViewModel>.Success(CashViewModel.FromEntity(model));
    }

    public ResultViewModel<CashViewModel> UpdateCashForMonth(Cash model)
    {
        var cash = _context.Cash
            .SingleOrDefault(c => c.Id == model.Id && !c.IsDeleted);
        if (cash == null)
            return ResultViewModel<CashViewModel>.Error("Caixa não encontrado");

        cash.Update(model);
        _context.SaveChanges();
        
        return ResultViewModel<CashViewModel>.Success(CashViewModel.FromEntity(cash));
    }

    public ResultViewModel<CashViewModel> DeleteCashForMonth(int id)
    {
        var cash = _context.Cash
            .SingleOrDefault(c => c.Id == id && !c.IsDeleted);
        if (cash == null)
            return ResultViewModel<CashViewModel>.Error("Caixa não encontrado");

        cash.SetAsDelete();
        _context.SaveChanges();
        
        return ResultViewModel<CashViewModel>.Success(CashViewModel.FromEntity(cash));
    }
}