using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class ItemController : Controller
    {
        InventoryManagerContext db = new InventoryManagerContext();
        public IActionResult Index()
        {
            return View();
        }
    }
}
