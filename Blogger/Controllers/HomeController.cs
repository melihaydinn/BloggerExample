using Microsoft.AspNetCore.Mvc;
using System.Data;


namespace Blogger.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
