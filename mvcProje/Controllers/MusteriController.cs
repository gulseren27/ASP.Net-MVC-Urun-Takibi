using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcProje.Models.Entity;
namespace mvcProje.Controllers
{
    public class MusteriController : Controller
    {

        MvcProjectEntities db = new MvcProjectEntities();
        // GET: Musteri
        public ActionResult IndexMusteriler()
        {
            var degerler = db.TBLMUSTERILER.ToList();

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
            db.TBLMUSTERILER.Add(p1);
            db.SaveChanges();
            return View();
        }

        public ActionResult SIL(int id)
        {
            var musteri = db.TBLMUSTERILER.Find(id);
            db.TBLMUSTERILER.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("IndexMusteriler");



        }
    }
}
