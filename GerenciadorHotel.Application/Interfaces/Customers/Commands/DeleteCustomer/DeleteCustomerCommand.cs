using GerenciadorHotel.Application.Models;
using MediatR;

namespace GerenciadorHotel.Application.Interfaces.Customers.Commands.DeleteCustomer;

public class DeleteCustomerCommand : IRequest<ResultViewModel>
{
    public DeleteCustomerCommand(int id)
    {
        Id = id;
    }
    
    public int Id { get; set; }
}