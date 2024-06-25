using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sube1_HELLOMVC.Controllers
{

    public class OgrenciDersleriController : Controller
    {
        public IActionResult Index()
        {
            List<OgrenciDers> lst = null;
            using (var ctx = new OkulDbContext())
            {
                lst = ctx.ogrenciDersler.ToList();
            }
            return View(lst);


        }





        [HttpGet]
        public IActionResult alinanDersler(int ogrenciid)
        {


            List<OgrenciDers> ogDersleri;
            using (var ctx = new OkulDbContext())
            {
                ogDersleri = ctx.ogrenciDersler.Include(od => od.ders).Include(od => od.Ogrenci).Where(od => od.Ogrenciid == ogrenciid).ToList();
                ViewBag.OgrenciId = ogrenciid;
            }
            return View(ogDersleri);
        }
        [HttpGet]
        public IActionResult OgrenciDersEkle(int ogrenciid)
        {
            using (var ctx = new OkulDbContext())
            {
                var lst = ctx.ogrenciDersler.Where(od => od.Ogrenciid == ogrenciid).Select(od => od.Dersid).ToList();

                var lst2 = ctx.Dersler.Where(d => !lst.Contains(d.Dersid)).ToList();
                ViewData["OgrenciId"] = ogrenciid;
                return View(lst2);
            }
        }

        [HttpPost]
        public IActionResult OgrenciDersEkle(int ogrenciid, int dersid)
        {

            var ogrenciDers = new OgrenciDers
            {
                Ogrenciid = ogrenciid,
                Dersid = dersid
            };
            using (var ctx = new OkulDbContext())
            {
                ctx.ogrenciDersler.Add(ogrenciDers);
                ctx.SaveChanges();
            }
            return RedirectToAction("alinanDersler", new { Ogrenciid = ogrenciid });
        }
    }
}

