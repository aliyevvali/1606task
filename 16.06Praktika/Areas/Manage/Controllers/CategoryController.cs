using _16._06Praktika.DAL;
using _16._06Praktika.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace _16._06Praktika.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Category> categories = _context.Categories.ToList(); 
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
           
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            Category category  = _context.Categories.Find(id);
            if(category == null) return NotFound();
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            Category category1 = _context.Categories.FirstOrDefault(c => c.Id == category.Id);
            if (category1 == null) return NotFound();

            category1.CategoryName = category.CategoryName;
            _context.SaveChanges();
            return RedirectToAction();
        }
        public IActionResult Delete(int id)
        {
            Category category = _context.Categories.FirstOrDefault(x=>x.Id == id);
            if(category==null) return NotFound();
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return View();
        }
    }
}
