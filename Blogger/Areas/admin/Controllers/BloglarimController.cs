using Blogger.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Blogger.Areas.admin.Controllers
{
    [Area("admin")]
    public class BloglarimController : Controller
    {
        private DatabaseContext db;
        public BloglarimController(DatabaseContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View(db.Blogs.ToList());
        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(Blogs blogs, IFormFile file)
        {
            if (file != null)
            {
                string DosyaAdi = ImageUpload(file);
                if (DosyaAdi != null)
                {
                    blogs.Images = DosyaAdi;
                    blogs.PublishDate = DateTime.Now;
                    db.Blogs.Add(blogs);
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
        [Route("/admin/Bloglarim/Update/{id:int}")]
        public IActionResult Update(int id)
        {
            // var ise Tek Satır Yoksa NULL;
            return View(db.Blogs.Find(id));
        }
        [HttpPost]
        [Route("/admin/Bloglarim/Update/{id:int}")]
        public IActionResult Update(int id, Blogs blogs, IFormFile file)
        {
            var bulunan = db.Blogs.Find(id);
            if (file != null)
            {
                string DosyaAdi = ImageUpload(file);
                if (DosyaAdi != null)
                {
                    bulunan.Images = DosyaAdi;
                }
                else
                {
                    ViewBag.Messages = "Lütfen jpg,jpeg,png uzantılı dosya seçmediğiniz için Resim Güncellenemedi.";
                }
            }
            bulunan.Explanation = blogs.Explanation;
            bulunan.BlogName = blogs.BlogName;
            db.SaveChanges();
            return View(db.Blogs.Find(id));
        }
        [HttpGet]
        [Route("/admin/Bloglarim/Delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            var bulunan = db.Blogs.Find(id);
            db.Blogs.Remove(bulunan);
            db.SaveChanges();
            return Redirect("/admin/Bloglarim");
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
