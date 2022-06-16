using _16._06Praktika.DAL;
using _16._06Praktika.ViewModes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace _16._06Praktika.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HomeVm homeVm = new HomeVm()
            {
                Menus = _context.Menus.ToList(),
                Categories = _context.Categories.ToList()
            };
            return View(homeVm);
        }

       
    }
}
