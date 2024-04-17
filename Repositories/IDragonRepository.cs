using midterm_project.Models;

namespace midterm_project.Repositories;

public interface IDragonrepository 
{
    IEnumerable<Dragon> GetAllDragons();
    Dragon? GetDragonById(int dragonId);
    Dragon CreateDragon(Dragon dragon);
    Dragon? UpdateDragon(Dragon dragon);
    void DeleteDragonById(int dragonId);
}