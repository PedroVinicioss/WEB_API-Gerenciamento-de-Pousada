using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.InputModels;
using GerenciadorHotel.Application.Models.ViewModels;
using GerenciadorHotel.Infrastructure.Persistence;

namespace GerenciadorHotel.Application.Interfaces.Product.Services;

public class ProductService : IProductService
{
    AppDbContext _context;
    
    public ProductService(AppDbContext context)
    {
        _context = context;
    }
    
    public ResultViewModel<List<ProductViewModel>> GetAll(string search = "")
    {
        var products = _context.Products
            .Where(p => !p.IsDeleted && (search == "" || p.Name.Contains(search) || p.Description.Contains(search)))
            .Select(p => ProductViewModel.FromEntity(p))
            .ToList();
        
        return ResultViewModel<List<ProductViewModel>>.Success(products);
    }

    public ResultViewModel<ProductViewModel> GetById(int id)
    {
        var product = _context.Products.SingleOrDefault(p => !p.IsDeleted && p.Id == id);
        if(product is null)
            return ResultViewModel<ProductViewModel>.Error("Produto não encontrado");
        
        var model = ProductViewModel.FromEntity(product);
        
        return ResultViewModel<ProductViewModel>.Success(model);
    }

    public ResultViewModel<int> Insert(CreateProductInputModel model)
    {
        var product = model.ToEntity();
        
        _context.Products.Add(product);
        _context.SaveChanges();
        
        return ResultViewModel<int>.Success(product.Id);
    }

    public ResultViewModel Update(Core.Entities.Product model)
    {
        var product = _context.Products.SingleOrDefault(p => !p.IsDeleted && p.Id == model.Id);
        if(product is null)
            return ResultViewModel.Error("Produto não encontrado");
        
        product.Update(model.Name, model.Description, model.Price, model.IsAvailable, model.Category, model.Stock);
        
        _context.Update(product);
        _context.SaveChanges();
        
        return ResultViewModel.Success();
    }

    public ResultViewModel Delete(int id)
    {
        var product = _context.Products.SingleOrDefault(p => !p.IsDeleted && p.Id == id);
        if(product is null)
            return ResultViewModel.Error("Produto não encontrado");
        
        product.SetAsDelete();
        
        _context.Update(product);
        _context.SaveChanges();
        
        return ResultViewModel.Success();
    }
}