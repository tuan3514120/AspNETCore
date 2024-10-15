using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shopping.Insfrastructure;
using Shopping.Models;

namespace Shopping.Controllers
{
    public class ProductsController : Controller
    {
        private readonly DataContext _context;

        public ProductsController(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string categorySlug ="", int p=1)
        {
            int pageSize = 8;
            ViewBag.PageNumber = p;
            ViewBag.PageRange = pageSize;
            ViewBag.CategorySlug=categorySlug;

            if (categorySlug == "")
            {
                ViewBag.TotalPages = (int)Math.Ceiling((decimal)_context.Products.Count()/pageSize);
                return View(await _context.Products.OrderByDescending(p=>p.Id).Skip((p-1)*pageSize).Take(pageSize).ToListAsync()) ;
            }
            Category category = await _context.Categories.Where(c => c.Slug == categorySlug).FirstOrDefaultAsync();
            if(category == null) return RedirectToAction("Index");

            var productsByCategory = _context.Products.Where(p => p.CategoryId == category.Id);
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)productsByCategory.Count() / pageSize);
            return View(await productsByCategory.OrderByDescending(p=>p.Id).Skip((p-1)*pageSize).Take(pageSize).ToListAsync());
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
         
    }
}
