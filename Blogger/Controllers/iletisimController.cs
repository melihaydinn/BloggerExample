using Microsoft.AspNetCore.Mvc;

namespace Blogger.Controllers
{
    public class iletisimController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
