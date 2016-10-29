using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCSH.Models;
using MVCSH.Data;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MVCSH.Controllers
{
    public class WineriesController : Controller
    {
        private ApplicationDbContext _context; // Link Between This Controller And My DB - Comuinication Between The WEbsite And The DB

        public WineriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Winery> wineries = _context.Winery.ToList();
            return View(wineries);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] // Will Ensure That This Method Will Be Trigerd When Data Is Post Back From The View
        [ValidateAntiForgeryToken]
        public IActionResult Create(Winery winery) // Winery as an Input // this method is accessible by Post Back Event Using An Action Filter
        {
            //Check If The Models Check Are Valid

            if (ModelState.IsValid)
            {
                // Add To Context Object
                _context.Winery.Add(winery);
                _context.SaveChanges(); // Save Data To The DB
                return RedirectToAction("Index");
            }

            return View(winery); // Return The View With Errors
        }
    }
}
