using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.InputModels;
using GerenciadorHotel.Application.Models.ViewModels;

namespace GerenciadorHotel.Application.Interfaces.Product.Services;

public interface IProductService
{
    ResultViewModel<List<ProductViewModel>> GetAll(string search = "");
    ResultViewModel<ProductViewModel> GetById(int id);
    ResultViewModel<int> Insert(CreateProductInputModel model);
    ResultViewModel Update(Core.Entities.Product model);
    ResultViewModel Delete(int id);
}