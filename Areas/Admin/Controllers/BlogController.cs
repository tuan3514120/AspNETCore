using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shopping.Insfrastructure;
using Shopping.Models;

namespace Shopping.Areas.Admin.Controllers
{
		[Area("Admin")]
		[Authorize]
	public class BlogController : Controller
	{

		private readonly DataContext _context;
		private readonly IWebHostEnvironment _webHostEnvironment;

		public BlogController(DataContext context, IWebHostEnvironment webHostEnvironment)
		{
			_context = context;
			_webHostEnvironment = webHostEnvironment;
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
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Blog blog)
		{
			if (ModelState.IsValid)
			{
				blog.Slug = blog.Name.ToLower().Replace(" ", "-");

				var slug = await _context.Blogs.FirstOrDefaultAsync(p => p.Slug == blog.Slug);
				if (slug != null)
				{
					ModelState.AddModelError("", "Bài viết đã tồn tại!");
					return View(blog);
				}

				if (blog.ImageUpload != null)
				{
					string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "images");
					string imageName = Guid.NewGuid().ToString() + "_" + blog.ImageUpload.FileName;

					string filePath = Path.Combine(uploadsDir, imageName);

					FileStream fs = new FileStream(filePath, FileMode.Create);
					await blog.ImageUpload.CopyToAsync(fs);
					fs.Close();

					blog.Image = imageName;
				}

				_context.Add(blog) ;
				await _context.SaveChangesAsync();

				TempData["Name"] = "Thêm bài viết thành công!";

				return RedirectToAction("Index");
			}

			return View(blog);
		}

		public async Task<IActionResult> Edit(long id)
		{
			Blog blog = await _context.Blogs.FindAsync(id);
			return View(blog);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, Blog blog)
		{

			if (ModelState.IsValid)
			{
				blog.Slug = blog.Name.ToLower().Replace(" ", "-");

				var slug = await _context.Blogs.FirstOrDefaultAsync(p => p.Slug == blog.Slug);
				if (slug != null)
				{
					ModelState.AddModelError("", "Bài viết đã tồn tại!");
					return View(blog);
				}

				if (blog.ImageUpload != null)
				{
					string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "images");
					string imageName = Guid.NewGuid().ToString() + "_" + blog.ImageUpload.FileName;

					string filePath = Path.Combine(uploadsDir, imageName);

					FileStream fs = new FileStream(filePath, FileMode.Create);
					await blog.ImageUpload.CopyToAsync(fs);
					fs.Close();

					blog.Image = imageName;
				}

				_context.Update(blog);
				await _context.SaveChangesAsync();

				TempData["Name"] = "Cập nhật bài viết thành công!";
				return RedirectToAction("Index");

			}

			return View(blog);
		}
		public async Task<IActionResult> Delete(long id)
		{
			Blog blog = await _context.Blogs.FindAsync(id);
			if (!string.Equals(blog.Image, "noimage.png"))
			{
				string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "images");
				string oldImagePath = Path.Combine(uploadsDir, blog.Image);
				if (System.IO.File.Exists(oldImagePath))
				{
					System.IO.File.Delete(oldImagePath);
				}
			}
			_context.Blogs.Remove(blog);
			await _context.SaveChangesAsync();
			TempData["Name"] = "Xóa bài viết thành công!";
			return RedirectToAction("Index");
		}
	}
}
