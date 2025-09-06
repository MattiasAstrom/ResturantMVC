using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResturantMVC.Models;
using ResturantMVC.ViewModels;

namespace ResturantMVC.Controllers
{
    public class MenuItemController : Controller
    {
        private readonly HttpClient _client;

        public MenuItemController(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("ResturantAPI");
        }

        public async Task<IActionResult> Index()
        {
            var response = await _client.GetAsync("MenuItems/GetAllMenuItems");

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Error retrieving menu items.");
                return View(new List<MenuItem>());
            }

            var menuItems = await response.Content.ReadFromJsonAsync<List<MenuItem>>();

            return View(menuItems);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMenuItemVM newItem)
        {
            if (!ModelState.IsValid)
                return View(newItem);



            var response = await _client.PostAsJsonAsync("MenuItems/AddMenuItem", newItem);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Failed to add the menu item.");
                return View(newItem);
            }

            TempData["SuccessMessage"] = "Menu item created successfully!";
            return RedirectToAction("Index");

        }
    }
}
