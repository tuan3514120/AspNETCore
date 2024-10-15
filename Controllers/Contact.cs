using Microsoft.AspNetCore.Mvc;

namespace Shopping.Controllers
{
    public class Contact : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
