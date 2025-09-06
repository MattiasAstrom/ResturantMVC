using Microsoft.AspNetCore.Mvc;

namespace ResturantMVC.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
