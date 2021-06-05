using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcStok.Models.Entity;

namespace mvcStok.Controllers
{
    public class MusteriController : Controller
    {
        mvcWebEntities1 db = new mvcWebEntities1();
        // GET: Musteri
        public ActionResult Index(String p)
        {
            //var degerler = db.tblMusteriler.ToList();
            var degerler = from d in db.tblMusteriler select d;//degerleri  tek tek seciyor
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.musteriAd.Contains(p));
            }
            return View(degerler.ToList());
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult YeniMusteri(tblMusteriler p1)
        {

            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.tblMusteriler.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        {
            var deger = db.tblMusteriler.Find(id);
            db.tblMusteriler.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult MusteriGetir(int id)
        {
            var mus = db.tblMusteriler.Find(id);
            return View("MusteriGetir", "mus");
        }
        public ActionResult Guncelle(tblMusteriler p1)
        {
            var ktgr = db.tblMusteriler.Find(p1.musteriId);
            ktgr.musteriAd = p1.musteriAd;
            ktgr.musteriSoyad = p1.musteriSoyad;
            db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}