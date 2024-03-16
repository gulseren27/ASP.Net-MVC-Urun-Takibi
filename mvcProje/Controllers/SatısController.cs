using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
    }
}