using Blogger.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blogger.ViewComponents
{
    public class MenulerViewComponent:ViewComponent
    {
        private DatabaseContext db;
        public MenulerViewComponent(DatabaseContext db) 
        {
            this.db = db;
        }
        public IViewComponentResult Invoke()
        {
            return View(db.Pages.ToList());
        }
    }
}
