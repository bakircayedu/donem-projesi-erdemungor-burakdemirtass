using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStokTakip.Models.Entity;


namespace MVCStokTakip.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        DbMvcStokEntities db = new DbMvcStokEntities();

        public ActionResult Indexx()
        {
            var kategoriler = db.tblKategori.ToList();
            return View(kategoriler);
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();

        }
        [HttpPost]
        public ActionResult YeniKategori(tblKategori p)
        {
            db.tblKategori.Add(p);
            db.SaveChanges();
            return RedirectToAction("Indexx");

        }
        public ActionResult KategoriSil(int id)
        {
            var ktg = db.tblKategori.Find(id);
            db.tblKategori.Remove(ktg);
            db.SaveChanges();
            return RedirectToAction("Indexx");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.tblKategori.Find(id);
            return View("KategoriGetir", ktgr);

        }
        public ActionResult KategoriGuncelle(tblKategori k)
        {
            var ktg = db.tblKategori.Find(k.kategoriId);
            ktg.kategoriAd = k.kategoriAd;
            db.SaveChanges();
            return RedirectToAction("Indexx");



        }


    }
}