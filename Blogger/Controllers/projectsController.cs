using Blogger.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blogger.Controllers
{
    public class projectsController : Controller
    {
        private DatabaseContext db;
        public projectsController(DatabaseContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View(db.Projects.ToList());
        }
    }
}
