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
        _db.Categorties.Add(obj);
        _db.SaveChanges();
        TempData["success"] = "Category created successfully";
        return RedirectToAction("Index");
        

    }

    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        Categorty? categoryFromDb = _db.Categorties.Find(id);
        //Categorty categoryFromDb = _db.Categorties.Where(u => u.Id == id);
        //Categorty? categoryFromDb = _db.Categorties.FirstOrDefault(u => u.Id == id);
        if (categoryFromDb == null)
        {
            return NotFound();

        }

        return View(categoryFromDb);

    }

    [HttpPost]
    public IActionResult Edit(Categorty obj)
    {
        if (ModelState.IsValid)
        {
            _db.Categorties.Update(obj);
            _db.SaveChanges();
            
            TempData["success"] = "Category edited successfully";
            return RedirectToAction("Index");
        }

        return View();
    }

    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        Categorty? categoryFromDb = _db.Categorties.FirstOrDefault(u => u.Id == id);
        return View(categoryFromDb);
    }
    [HttpPost,ActionName("Delete")]
    public IActionResult DeleteCategory(int? id)
    {
        Categorty? obj = _db.Categorties.FirstOrDefault(u => u.Id == id);
        if (obj == null)
        {
            return NotFound();
        }

        _db.Categorties.Remove(obj);
        _db.SaveChanges();
        
        TempData["success"] = "Category deleted successfully";
        return RedirectToAction("Index");
    }
}


