using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcProje.Models.Entity;

namespace mvcProje.Controllers
{
    public class KategoriController : Controller
    {


        MvcProjectEntities db = new MvcProjectEntities();
        // GET: Kategori


        
        public ActionResult IndexKategori()
        {

            var degerler = db.TBLKATEGORILER.ToList();

            return View(degerler);
        }

        [HttpGet]
        public ActionResult YENIKATEGORI()
        {
            return View();
        }

        [HttpPost]

        public ActionResult YENIKATEGORI(TBLKATEGORILER p1)
        {

            if (!ModelState.IsValid)
            {
                return View("YENIKATEGORI");
            }
            db.TBLKATEGORILER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("IndexKategori");
            
}
    

        public ActionResult SIL(int id)
        {
            var kategori = db.TBLKATEGORILER.Find(id);
            db.TBLKATEGORILER.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("IndexKategori");



        }

          public ActionResult KATEGORİGETİR(int id)
        {
            var ktgr = db.TBLKATEGORILER.Find(id);
            return View("KATEGORİGETİR", ktgr);
        }

        public ActionResult GUNCELLE(TBLKATEGORILER p1)
        {

            var ktg = db.TBLKATEGORILER.Find(p1.KATEGORIID);
            ktg.KATEORIAD = p1.KATEORIAD;
            db.SaveChanges();
            return RedirectToAction("IndexKategori");


        }

    }

}