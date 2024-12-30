using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHotel.Application.Interfaces.Room.Commands.UpdateRoom;

public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand, ResultViewModel>
{
    private readonly AppDbContext _context;

    public UpdateRoomCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ResultViewModel> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
    {
        var room = await _context.Rooms.SingleOrDefaultAsync(r => r.Id == request.Id);
        if (room is null)
            return ResultViewModel.Error("Quarto não encontrado.");
        
        room.Update(request.ToEntity());
        
        _context.Rooms.Update(room);
        await _context.SaveChangesAsync(cancellationToken);
        
        return ResultViewModel.Success();
    }
}