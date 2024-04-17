using midterm_project.Migrations;
using midterm_project.Models;

namespace midterm_project.Repositories;

public class EFDragonRepository : IDragonrepository
{

    private readonly DragonDbContext _context;

    public EFDragonRepository(DragonDbContext context ) 
    {
        _context = context;
    }
    public Dragon CreateDragon(Dragon dragon)
    {
        _context.Dragon.Add(dragon);
        _context.SaveChanges();
        return dragon;
    }

    public void DeleteDragonById(int dragonId)
    {
        var dragon = _context.Dragon.Find(dragonId);
        if (dragon != null) {
            _context.Dragon.Remove(dragon);
            _context.SaveChanges();
        }
    }

    public IEnumerable<Dragon> GetAllDragons()
    {
        return _context.Dragon.ToList();
    }

    public Dragon? GetDragonById(int dragonId)
    {
        return _context.Dragon.SingleOrDefault(d => d.Id == dragonId);
    }

    public Dragon? UpdateDragon(Dragon dragon)
    {
        var ogDragon = _context.Dragon.Find(dragon.Id);
        if (ogDragon != null) {
            ogDragon.Name = dragon.Name;
            ogDragon.ImgUrl = dragon.ImgUrl;
            ogDragon.Description = dragon.Description;
            ogDragon.Age = dragon.Age;
            _context.SaveChanges();
        }
        return ogDragon;
    }
}
