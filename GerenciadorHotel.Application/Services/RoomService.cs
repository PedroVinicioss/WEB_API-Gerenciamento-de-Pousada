using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.InputModels;
using GerenciadorHotel.Application.Models.ViewModels;
using GerenciadorHotel.Infrastructure.Persistence;

namespace GerenciadorHotel.Application.Services;

public class RoomService : IRoomService
{
    private AppDbContext _context;
    
    public RoomService(AppDbContext context)
    {
        _context = context;
    }
    
    public ResultViewModel<List<RoomViewModel>> GetAll(string search = "")
    {
        var rooms = _context.Rooms
            .Where(r => !r.IsDeleted && (search == "" || r.RoomName.Contains(search) || r.Description.Contains(search)))
            .Select(r => RoomViewModel.FromEntity(r))
            .ToList();
        
        return ResultViewModel<List<RoomViewModel>>.Success(rooms);
    }

    public ResultViewModel<RoomViewModel> GetById(int id)
    {
        var room = _context.Rooms.SingleOrDefault(r => r.Id == id);
        if (room is null)
            return ResultViewModel<RoomViewModel>.Error("Quarto não encontrado.");
        
        var roomViewModel = RoomViewModel.FromEntity(room);
        return ResultViewModel<RoomViewModel>.Success(roomViewModel);
    }

    public ResultViewModel<int> Insert(CreateRoomInputModel model)
    {
        var room = model.ToEntity();
        
        _context.Rooms.Add(room);
        _context.SaveChanges();
        
        return ResultViewModel<int>.Success(room.Id);
    }

    public ResultViewModel Update(UpdateRoomInputModel model)
    {
        var room = _context.Rooms.SingleOrDefault(r => r.Id == model.Id);
        if (room is null)
            return ResultViewModel.Error("Quarto não encontrado.");
        
        room.Update(model.ToEntity());
        
        _context.SaveChanges();
        return ResultViewModel<RoomViewModel>.Success();
    }

    public ResultViewModel Delete(int id)
    {
        var room = _context.Rooms.SingleOrDefault(r => r.Id == id);
        if (room is null)
            return ResultViewModel.Error("Quarto não encontrado.");
        
        room.SetAsDelete();
        
        _context.SaveChanges();
        return ResultViewModel.Success();
    }
}