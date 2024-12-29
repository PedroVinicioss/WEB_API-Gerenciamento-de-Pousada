using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.ViewModels;
using MediatR;

namespace GerenciadorHotel.Application.Interfaces.User.Queries.GetAllUsers;

public class GetAllUsersQuery : IRequest<ResultViewModel<List<UserItemViewModel>>>
{
    public GetAllUsersQuery(string search)
    {
        Search = search;
    }
    
    public string? Search { get; set; }
}