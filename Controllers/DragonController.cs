using midterm_project.Repositories;
using midterm_project.Models;
using Microsoft.AspNetCore.Mvc;

namespace midterm_project.Controllers;

public class DragonController : Controller
{
    private readonly ILogger<DragonController> _ilogger;
    private readonly IDragonrepository _dragonRepository;

    public DragonController(ILogger<DragonController> logger, IDragonrepository dragonRepository)
    {
        _ilogger = logger;
        _dragonRepository = dragonRepository;
    }

    public IActionResult List() 
    {
        return View(_dragonRepository.GetAllDragons());
    }

    public IActionResult Detail (int id) 
    {
        var dragon = _dragonRepository.GetDragonById(id);

        if (dragon == null) {
            return RedirectToAction("List");
        }

        return View(dragon);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var dragon = _dragonRepository.GetDragonById(id);

        return View(dragon);
    }

    [HttpPost]
    public IActionResult Edit(Dragon dragon)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        _dragonRepository.UpdateDragon(dragon);

        return RedirectToAction("Detail");
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(Dragon dragon)
    {
        if (!ModelState.IsValid) 
        {
            return View();
        }
        _dragonRepository.CreateDragon(dragon);

        return RedirectToAction("Detail", new { id = dragon.Id});
    }

    public IActionResult Delete(int id)
    {
        _dragonRepository.DeleteDragonById(id);

        return RedirectToAction("List");
    }
}
