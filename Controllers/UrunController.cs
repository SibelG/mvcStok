using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcStok.Models.Entity;

namespace mvcStok.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        mvcWebEntities1 db = new mvcWebEntities1();
        public ActionResult Index()
        {
            var degerler = db.tblUrun.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> degerler = (from i in db.tblKategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.kategoriAd,
                                                 Value = i.kategoriId.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(tblUrun p1)
        {
            var ktg = db.tblKategoriler.Where(m => m.kategoriId == p1.tblKategoriler.kategoriId).FirstOrDefault();
            p1.tblKategoriler = ktg;
            db.tblUrun.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Sil(int id)
        {
            var urun = db.tblUrun.Find(id);
            db.tblUrun.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult UrunGetir(int id)
        {
            var urun = db.tblUrun.Find(id);
            List<SelectListItem> degerler = (from i in db.tblKategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.kategoriAd,
                                                 Value = i.kategoriId.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("UrunGetir", urun);
        }
        public ActionResult Guncelle(tblUrun p)
        {
            var urun = db.tblUrun.Find(p.urunId);
            urun.urunAd = p.urunAd;
            urun.urunMarka = p.urunMarka;
            urun.stok = p.stok;
            urun.fiyat = p.fiyat;
            //urun.urunKategori = p.urunKategori;
            var ktg = db.tblKategoriler.Where(m => m.kategoriId == p.tblKategoriler.kategoriId).FirstOrDefault();
            urun.urunKategori = ktg.kategoriId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}