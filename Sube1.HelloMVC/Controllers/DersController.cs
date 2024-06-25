using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace Sube1_HELLOMVC.Controllers
{
    public class DersController : Controller
    {
        public IActionResult Index()
        {
            List<Ders> lst = null;
            using (var ctx = new OkulDbContext())
            {
                lst = ctx.Dersler.ToList();
                ViewData["list"] = lst;
            }
            return View(lst);
        }

        public IActionResult AddDers()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDers(Ders ders)
        {
            if (ders != null)
            {
                using (var ctx = new OkulDbContext())
                {
                    ctx.Dersler.Add(ders);
                    ctx.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult EditDers(int id)
        {
            Ders ders = null;
            using (var ctx = new OkulDbContext())
            {
                ders = ctx.Dersler.Find(id);
            }
            return View(ders);
        }
        [HttpPost]
        public IActionResult EditDers(Ders ders)
        {
            using (var ctx = new OkulDbContext())
            {
                ctx.Entry(ders).State = EntityState.Modified;
                ctx.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeleteDers(int id)
        {
            using (var ctx = new OkulDbContext())
            {
                ctx.Dersler.Remove(ctx.Dersler.Find(id));
                ctx.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}





