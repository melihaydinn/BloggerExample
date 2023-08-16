using Blogger.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blogger.Areas.admin.Controllers
{
    [Area("admin")]
    public class YorumlarController : Controller
    {
        private DatabaseContext db;
        public YorumlarController(DatabaseContext db)
        {
            this.db = db;
        }
        [Route("/admin/Yorumlar/{id}")]
        public IActionResult Index(int id)
        {
            return View(db.BlogComments.Where(x=> x.BlogId == id));
        }
    }
}
