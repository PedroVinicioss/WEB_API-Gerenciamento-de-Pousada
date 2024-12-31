using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.ViewModels;
using MediatR;

namespace GerenciadorHotel.Application.Interfaces.Customers.Queries.GetAllCustomers;

public class GetAllCustomersQuery : IRequest<ResultViewModel<List<CustomerItemViewModel>>>
{
    public GetAllCustomersQuery(string search)
    {
        Search = search;
    }
    
    public string? Search { get; set; }
}