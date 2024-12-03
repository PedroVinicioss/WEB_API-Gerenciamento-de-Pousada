using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.InputModels;
using GerenciadorHotel.Application.Models.ViewModels;
using GerenciadorHotel.Core.Entities;
using GerenciadorHotel.Infrastructure.Persistence;

namespace GerenciadorHotel.Application.Services;

public class ConsumptionService : IConsumptionService
{
    private AppDbContext _context;
    
    public ConsumptionService(AppDbContext context)
    {
        _context = context;
    }
    
    public ResultViewModel<List<ConsumptionViewModel>> GetAll()
    {
        var consumptions = _context.Consumptions
            .Select(c => ConsumptionViewModel.FromEntity(c))
            .ToList();
        
        return ResultViewModel<List<ConsumptionViewModel>>.Success(consumptions);
    }

    public ResultViewModel<ConsumptionViewModel> GetById(int id)
    {
        var consumption = _context.Consumptions.SingleOrDefault(c => c.Id == id);
        if(consumption is null)
            return ResultViewModel<ConsumptionViewModel>.Error("Consumo não encontrado");
        
        var model = ConsumptionViewModel.FromEntity(consumption);
        
        return ResultViewModel<ConsumptionViewModel>.Success(model);
    }

    public ResultViewModel<int> Insert(CreateConsumptionInputModel model)
    {
        var consumption = model.ToEntity();
        
        _context.Consumptions.Add(consumption);
        _context.SaveChanges();
        
        return ResultViewModel<int>.Success(consumption.Id);
    }

    public ResultViewModel Update(Consumption model)
    {
        var consumption = _context.Consumptions.SingleOrDefault(c => c.Id == model.Id);
        if(consumption is null)
            return ResultViewModel.Error("Consumo não encontrado");
        
        consumption.Update(model);
        
        _context.Update(consumption);
        _context.SaveChanges();
        
        return ResultViewModel.Success();
    }

    public ResultViewModel Delete(int id)
    {
        var consumption = _context.Consumptions.SingleOrDefault(c => c.Id == id);
        if(consumption is null)
            return ResultViewModel.Error("Consumo não encontrado");
        
        consumption.SetAsDelete();
        
        _context.Update(consumption);
        _context.SaveChanges();
        
        return ResultViewModel.Success();
    }
}