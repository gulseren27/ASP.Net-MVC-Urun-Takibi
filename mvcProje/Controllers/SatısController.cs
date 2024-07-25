using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using PagedList.Mvc;
using System.Web.Mvc;
using mvcProje.Models.Entity;

namespace mvcProje.Controllers
{
    public class SatısController : Controller
    {

        MvcProjectEntities db = new MvcProjectEntities();
        // GET: Satıs
        public ActionResult IndexSatıslar()
        {


            var degerler = db.TBLSATISLAR.ToList();

            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(TBLSATISLAR p)
        {
            db.TBLSATISLAR.Add(p);
            db.SaveChanges();
            return RedirectToAction("IndexsSatıslar");

        }
    }
}