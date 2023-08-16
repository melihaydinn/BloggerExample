using Blogger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blogger.Controllers
{
    public class HakkimdaController : Controller
    {
        private DatabaseContext db;
        public HakkimdaController(DatabaseContext db) {

            this.db = db;
        }
        [Route("/Sayfa/{id}")]
        public IActionResult Index(int id)
        {
            //AsNoTracking() => Select Sorgusu çalıştığında devamlı olarak arka planda Listelenen tabloda ekleme ve güncelleme olup olmadığını kontrol ettiği için, bu kod sayesinde bu izleme durdurulur. Sayfa Refresh yapınca yine güncel dataları sistem getirir.
            return View(db.Pages.Where(x=> x.id == id).AsNoTracking().FirstOrDefault());
        }
    }
}
