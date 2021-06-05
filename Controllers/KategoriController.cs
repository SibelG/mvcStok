using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcStok.Models.Entity;
using PagedList;
using PagedList.Mvc;


namespace mvcStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        mvcWebEntities1 db = new mvcWebEntities1();
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }
        public ActionResult Index(int sayfa=1)
        {
            //var values = db.tblKategoriler.ToList();//degerleri listele
            var values = db.tblKategoriler.ToList().ToPagedList(sayfa,4);
            return View(values);
        }
        [HttpPost]
        public ActionResult YeniKategori(tblKategoriler p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.tblKategoriler.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        {
            var kategori = db.tblKategoriler.Find(id);
            db.tblKategoriler.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.tblKategoriler.Find(id);
            return View("KategoriGetir", ktgr);
        }
        public ActionResult Guncelle(tblKategoriler p1)
        {
            var ktgr = db.tblKategoriler.Find(p1.kategoriId);
            ktgr.kategoriAd = p1.kategoriAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}