using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.ViewModels;
using GerenciadorHotel.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHotel.Application.Interfaces.Room.Queries.GetRoomById;

public class GetRoomByIdQueryHandler : IRequestHandler<GetRoomByIdQuery, ResultViewModel<RoomViewModel>>
{
    private AppDbContext _context;
    
    public GetRoomByIdQueryHandler(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<ResultViewModel<RoomViewModel>> Handle(GetRoomByIdQuery request, CancellationToken cancellationToken)
    {
        var room = await _context.Rooms.SingleOrDefaultAsync(r => r.Id == request.Id);
        if (room is null)
            return ResultViewModel<RoomViewModel>.Error("Quarto não encontrado.");
        
        var roomViewModel = RoomViewModel.FromEntity(room);
        return ResultViewModel<RoomViewModel>.Success(roomViewModel); 
    }
}