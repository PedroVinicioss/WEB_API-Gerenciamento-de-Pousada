using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.ViewModels;
using GerenciadorHotel.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHotel.Application.Interfaces.Room.Queries.GetAllRooms;

public class GetAllRoomsQueryHandler : IRequestHandler<GetAllRoomsQuery, ResultViewModel<List<RoomViewModel>>>
{
    private readonly AppDbContext _context;

    public GetAllRoomsQueryHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ResultViewModel<List<RoomViewModel>>> Handle(GetAllRoomsQuery request, CancellationToken cancellationToken)
    {
        var rooms = await _context.Rooms
            .Where(r => !r.IsDeleted && (request.Search == "" || r.RoomName.Contains(request.Search) || r.Description.Contains(request.Search)))
            .Select(r => RoomViewModel.FromEntity(r))
            .ToListAsync(cancellationToken: cancellationToken);
        
        return ResultViewModel<List<RoomViewModel>>.Success(rooms);
    }
}