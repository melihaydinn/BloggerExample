using Blogger.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blogger.Controllers
{
    public class BloglarController : Controller
    {
        private DatabaseContext db;

        public BloglarController(DatabaseContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View(db.Blogs.ToList());
        }
    }
}
