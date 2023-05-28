using Microsoft.AspNetCore.Mvc;

namespace LogisticsApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
