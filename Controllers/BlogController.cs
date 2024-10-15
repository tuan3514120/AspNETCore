using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shopping.Insfrastructure;
using Shopping.Models;

namespace Shopping.Controllers
{
	public class BlogController : Controller
	{
		private readonly DataContext _context;

		public BlogController(DataContext context)
		{
			_context = context;
		}
		public async Task<IActionResult> Index(int p = 1)
		{
			int pageSize = 5;
			ViewBag.PageNumber = p;
			ViewBag.PageRange = pageSize;
			ViewBag.TotalPages = (int)Math.Ceiling((decimal)_context.Blogs.Count() / pageSize);
			return View(await _context.Blogs.OrderByDescending(p => p.Id)
				.Skip((p - 1) * pageSize)
				.Take(pageSize)
				.ToListAsync());
		}
        public async Task<IActionResult> Detail(long id, int p = 1)
        {
			int pageSize = 1;
			ViewBag.PageNumber = p;
			ViewBag.PageRange = pageSize;
			ViewBag.TotalPages = (int)Math.Ceiling((decimal)_context.Blogs.Count() / pageSize);
			return View(await _context.Blogs.OrderByDescending(p => p.Id)
				.Skip((p - 1) * pageSize)
				.Take(pageSize)
				.ToListAsync());
		}
    }
}
