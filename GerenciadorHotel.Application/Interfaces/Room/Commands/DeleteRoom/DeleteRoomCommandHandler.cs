using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHotel.Application.Interfaces.Room.Commands.DeleteRoom;

public class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommand, ResultViewModel>
{
    private readonly AppDbContext _context;
    
    public DeleteRoomCommandHandler(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<ResultViewModel> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
    {
        var room = await _context.Rooms.SingleOrDefaultAsync(r => r.Id == request.Id, cancellationToken: cancellationToken);
        if (room is null)
            return ResultViewModel.Error("Quarto não encontrado.");
        
        room.SetAsDelete();
        
        await _context.SaveChangesAsync(cancellationToken);
        return ResultViewModel.Success();
    }
}