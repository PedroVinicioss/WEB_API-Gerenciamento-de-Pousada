using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Infrastructure.Persistence;
using MediatR;

namespace GerenciadorHotel.Application.Interfaces.Room.Commands.CreateRoom;

public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, ResultViewModel<int>>
{
    private readonly AppDbContext _context;
    
    public CreateRoomCommandHandler(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<ResultViewModel<int>> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
    {
        var room = request.ToEntity();
        
        _context.Rooms.Add(room);
        await _context.SaveChangesAsync(cancellationToken);
        
        return ResultViewModel<int>.Success(room.Id);
    }
}