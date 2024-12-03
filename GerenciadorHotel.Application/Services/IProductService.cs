using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.InputModels;
using GerenciadorHotel.Application.Models.ViewModels;
using GerenciadorHotel.Core.Entities;

namespace GerenciadorHotel.Application.Services;

public interface IProductService
{
    ResultViewModel<List<ProductViewModel>> GetAll(string search = "");
    ResultViewModel<ProductViewModel> GetById(int id);
    ResultViewModel<int> Insert(CreateProductInputModel model);
    ResultViewModel Update(Product model);
    ResultViewModel Delete(int id);
}