using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using mvcProje.Models.Entity;
namespace mvcProje.Controllers
{
    public class MusteriController : Controller
    {

        MvcProjectEntities db = new MvcProjectEntities();
        // GET: Musteri
        public ActionResult IndexMusteriler(int sayfa = 1)
        {
            var degerler = db.TBLMUSTERILER.ToList().ToPagedList(sayfa,10);

            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERILER p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.TBLMUSTERILER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("IndexMusteriler");
        }

        public ActionResult SIL(int id)
        {
            var musteri = db.TBLMUSTERILER.Find(id);
            db.TBLMUSTERILER.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("IndexMusteriler");

        }
        public ActionResult MUSTERİGETİR(int id)
        {
            var mus = db.TBLMUSTERILER.Find(id);
            return View("MUSTERİGETİR", mus);
        }

           public ActionResult GUNCELLE(TBLMUSTERILER p1)
        {

            var mus = db.TBLMUSTERILER.Find(p1.MUSTERIID);
            mus.MUSTERIAD = p1.MUSTERIAD;
            mus.MUSTERISOYAD = p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("IndexMusteriler");


        }
    }
}
