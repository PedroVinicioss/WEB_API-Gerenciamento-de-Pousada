using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.ViewModels;
using MediatR;

namespace GerenciadorHotel.Application.Interfaces.User.Queries.GetUserById;

public class GetUserByIdQuery : IRequest<ResultViewModel<UserViewModel>>
{
    public GetUserByIdQuery(int id)
    {
        Id = id;
    }
    
    public int Id { get; set; }
}