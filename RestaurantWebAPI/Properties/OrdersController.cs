using Microsoft.AspNetCore.Mvc;

namespace RestaurantWebAPI.Properties
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
