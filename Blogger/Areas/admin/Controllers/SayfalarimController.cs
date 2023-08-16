using Blogger.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blogger.Areas.admin.Controllers
{
    [Area("admin")]
    public class SayfalarimController : Controller
    {
        private DatabaseContext db;
        public SayfalarimController(DatabaseContext db)
        {
             this.db = db;
        }
        public IActionResult Index()
        {
            return View(db.Pages.ToList());
        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(IFormFile file,Pages pages)
        {
            if (file != null)
            {
                string DosyaAdi = ImagesUpload(file);
                if (DosyaAdi != null)
                {
                    pages.Banners = DosyaAdi;
                    db.Pages.Add(pages);
                    db.SaveChanges();
                    ViewBag.Messages = "İşlem Başarılı";
                }
                else
                {
                    ViewBag.Messages = "jpg,jpeg veya Png uzantılı resim seçiniz.";
                }
            }
            else
            {
                ViewBag.Messages = "Lütfen Resim Seçiniz.";
            }
            return View();
        }

        [HttpGet]
        [Route("/admin/Sayfalarim/Update/{id}")]
        public IActionResult Update(int id)
        {
            return View(db.Pages.Find(id));
        }

        [HttpPost]
        [Route("/admin/Sayfalarim/Update/{id}")]
        public IActionResult Update(int id,Pages pages, IFormFile file)
        {
            var bulunan = db.Pages.Find(id);
            if (file != null)
            {
                string DosyaAdi = ImagesUpload(file);
                bulunan.Banners = DosyaAdi == null ? null : DosyaAdi;
            }
            bulunan.Explanation = pages.Explanation;
            bulunan.PageName = pages.PageName;
            db.SaveChanges();
            ViewBag.Message = "İşlem Başarılı";
            return View(db.Pages.Find(id));
        }
        [HttpGet]
        [Route("/admin/Sayfalarim/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var bulunan = db.Pages.Find(id);
            db.Pages.Remove(bulunan);
            db.SaveChanges();
            return Redirect("/admin/Sayfalarim");
        }
        private string ImagesUpload(IFormFile file)
        {
            string uzanti = Path.GetExtension(file.FileName);
            if (uzanti == ".jpg" || uzanti == ".jpeg" || uzanti == ".png")
            {
                string YeniAd = Guid.NewGuid() + uzanti;
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
