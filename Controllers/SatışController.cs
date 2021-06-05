using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcStok.Models.Entity;

namespace mvcStok.Controllers
{
    public class SatışController : Controller
    {
        mvcWebEntities1 db = new mvcWebEntities1();
        // GET: Satış
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(satis p)
        {
            db.satis.Add(p);
            db.SaveChanges();
            return View("Index");
        }
    }
}
