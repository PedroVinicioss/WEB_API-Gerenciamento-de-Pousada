using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.ViewModels;
using MediatR;

namespace GerenciadorHotel.Application.Interfaces.Customers.Queries.GetCustomerById;

public class GetCustomerByIdQuery : IRequest<ResultViewModel<CustomerViewModel>>
{
    public GetCustomerByIdQuery(int id)
    {
        Id = id;
    }
    
    public int Id { get; set; }
}