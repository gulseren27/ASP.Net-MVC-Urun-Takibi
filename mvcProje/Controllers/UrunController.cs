using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcProje.Models.Entity;
namespace mvcProje.Controllers
{
    public class UrunController : Controller
    {

        MvcProjectEntities db = new MvcProjectEntities();
        // GET: Urun
        public ActionResult IndexUrunler()
        {

            var degerler = db.TBLURUNLER.ToList();

            return View(degerler);
        }


        [HttpGet]
        public ActionResult YenıUrun()
        {
            List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return RedirectToAction("IndexUrunler");
        }

        [HttpPost]

        public ActionResult YenıUrun(TBLURUNLER p1)
        {
            var ktg = db.TBLKATEGORILER.Where(m => m.KATEGORIID == p1.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            p1.TBLKATEGORILER = ktg;
            db.TBLURUNLER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("IndexUrunler");

        }


        public ActionResult SIL(int id)
        {
            var urun = db.TBLURUNLER.Find(id);
            db.TBLURUNLER.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("IndexUrunler");



        }
    }
}