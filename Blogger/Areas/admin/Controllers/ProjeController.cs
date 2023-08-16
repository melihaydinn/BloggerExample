using Blogger.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blogger.Areas.admin.Controllers
{
    [Area("admin")]
    public class ProjeController : Controller
    {
        private DatabaseContext db;
        public ProjeController(DatabaseContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View(db.Projects.ToList());
        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(IFormFile file, Projects model)
        {
            if (file != null)
            {
                string DosyaAdi = ImageUpload(file);
                if (DosyaAdi != null)
                {
                    model.Images = DosyaAdi;
                    db.Projects.Add(model);
                    db.SaveChanges();
                    ViewBag.Messages = "İşlem Başarılı";
                }
                else
                {
                    ViewBag.Messages = "Lütfen jpg,jpeg,png uzantılı dosya seçiniz";
                }
            }
            else
            {
                ViewBag.Messages = "Lütfen Resim Seçiniz.";
            }
            return View();
        }
        [HttpGet]
        [Route("/admin/Proje/update/{id}")]
        public IActionResult update(int id)
        {
            return View(db.Projects.Find(id));
        }

        [HttpPost]
        [Route("/admin/Proje/update/{id}")]
        public IActionResult update(int id, IFormFile file, Projects model)
        {
            var bulunan = db.Projects.Find(id);
            if (file != null)
            {
                string DosyaAdi = ImageUpload(file);
                if (DosyaAdi != null)
                {
                    bulunan.Images = DosyaAdi;
                }
                bulunan.Explanation = model.Explanation;
                bulunan.ProjectName = model.ProjectName;
            }
            db.SaveChanges();
            ViewBag.Messages = "İşlem Başarılı";
            return View(db.Projects.Find(id));
        }
        [HttpGet]
        [Route("/admin/Proje/Delete/{id}")]
        public IActionResult delete(int id)
        {
            var bulunan = db.Projects.Find(id);
            db.Projects.Remove(bulunan);
            db.SaveChanges();
            return Redirect("/admin/Proje");
        }
        private string ImageUpload(IFormFile file)
        {
            string Uzanti = Path.GetExtension(file.FileName);
            if (Uzanti == ".jpg" || Uzanti == ".jpeg" || Uzanti == ".png")
            {
                string YeniAd = Guid.NewGuid() + Uzanti;
                string DosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{YeniAd}");
                using (var stream = new FileStream(DosyaYolu, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                return YeniAd;
            }
            else
            {
                return null;
            }
        }
    }
}
