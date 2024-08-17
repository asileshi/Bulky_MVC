using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _db;
    public CategoryController(ApplicationDbContext db)
    {
        _db = db;
    }
    // GET
    public IActionResult Index()
    {
        List<Categorty> objCategoryList = _db.Categorties.ToList();
        return View(objCategoryList);
    }

    public IActionResult Create() 
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(Categorty obj)
    {
        if (ModelState.IsValid)
        {
            _db.Categorties.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        return View();
    }
}