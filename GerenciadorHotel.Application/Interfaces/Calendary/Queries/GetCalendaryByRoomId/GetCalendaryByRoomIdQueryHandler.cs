using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHotel.Application.Interfaces.Calendary.Queries.GetCalendaryByRoomId;

public class GetCalendaryByRoomIdQueryHandler : IRequestHandler<GetCalendaryByRoomIdQuery, ResultViewModel<Core.Entities.Calendary>>
{
    private readonly AppDbContext _context;
    
    public GetCalendaryByRoomIdQueryHandler(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<ResultViewModel<Core.Entities.Calendary>> Handle(GetCalendaryByRoomIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.Calendars
            .FirstOrDefaultAsync(x => x.IdRoom == request.Id, cancellationToken: cancellationToken);
        
        if (entity is null)
            return ResultViewModel<Core.Entities.Calendary>.Error("Calendarios não encontrado.");
        
        return ResultViewModel<Core.Entities.Calendary>.Success(entity);
    }
}