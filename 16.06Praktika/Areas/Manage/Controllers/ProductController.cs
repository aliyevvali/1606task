using _16._06Praktika.DAL;
using _16._06Praktika.Models;
using _16._06Praktika.Uti;
using _16._06Praktika.ViewModes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _16._06Praktika.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _ev;

        public ProductController(AppDbContext context, IWebHostEnvironment ev)
        {
            _context = context;
            _ev = ev;
        }
        public IActionResult Index()
        {

            CategoryVM categoryVM = new CategoryVM
            {
                Categories = _context.Categories.ToList(),
                Menus = _context.Menus.ToList()
            };
            return View(categoryVM);
        }
        public IActionResult Create()
        {
            ViewBag.Cat = new SelectList(_context.Categories,nameof(Category.Id),nameof(Category.CategoryName));
            return View();
        }
        [HttpPost]
        public IActionResult Create(Menu menu)
        {
            ViewBag.Cat = new SelectList(_context.Categories, nameof(Category.Id), nameof(Category.CategoryName));
            menu.FoodImage = menu.Photo.SaveFile(Path.Combine(_ev.WebRootPath, "assets", "imgs", "menu"));

            _context.Menus.Add(menu);
            _context.SaveChanges();
            return  RedirectToAction("Index");

        }
        public IActionResult Delete(int id)
        {
            Menu menu = _context.Menus.Find(id);
            if (menu == null) return NotFound();
            _context.Menus.Remove(menu);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}
