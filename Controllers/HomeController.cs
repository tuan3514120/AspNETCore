using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shopping.Insfrastructure;
using Shopping.Models;
using System.Diagnostics;

namespace Shopping.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;

        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }



        public async Task<IActionResult> Index(int p = 1)
        {
            int pageSize = 8;
            ViewBag.PageNumber = p;
            ViewBag.PageRange = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)_context.Products.Count() / pageSize);
            return View(await _context.Products.OrderByDescending(p => p.Id)
                .Include(p => p.Category)
                .Skip((p - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync());

        }
        public async Task<IActionResult> Detail(long id, int p = 1)
        {
			int pageSize = 1;
			ViewBag.PageNumber = p;
			ViewBag.PageRange = pageSize;
			ViewBag.TotalPages = (int)Math.Ceiling((decimal)_context.Products.Count() / pageSize);
			return View(await _context.Products.OrderByDescending(p => p.Id)
				.Skip((p - 1) * pageSize)
				.Take(pageSize)
				.ToListAsync());
		}
        public IActionResult Blog()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}