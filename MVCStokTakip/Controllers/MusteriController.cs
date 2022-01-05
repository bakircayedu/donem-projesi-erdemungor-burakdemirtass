using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStokTakip.Models.Entity;
using PagedList;
using PagedList.Mvc;


namespace MVCStokTakip.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        DbMvcStokEntities db = new DbMvcStokEntities();
        [Authorize]

        public ActionResult Index(int sayfa=1)
        {
            // var musteriListe = db.tblMusteri.ToList();
            
            var musteriliste = db.tblMusteri.Where(x=>x.durum==true).ToList().ToPagedList(sayfa,5);
            return View(musteriliste);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();


        }
        [HttpPost]
        public ActionResult YeniMusteri(tblMusteri p)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");

            }
            p.durum = true;
            db.tblMusteri.Add(p);
 
            db.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult MusteriSil(int id)
        {
            var musteribul = db.tblMusteri.Find(id);
            musteribul.durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir (int id)
        {
            var mus = db.tblMusteri.Find(id);
            return View("MusteriGetir", mus);
        }
        public ActionResult MusteriGuncelle(tblMusteri t)
        {
            var mus = db.tblMusteri.Find(t.musteriId);
            mus.musteriAd = t.musteriAd;
            mus.musteriSoyad = t.musteriSoyad;
            mus.musteriSehir = t.musteriSehir;
            mus.musteriBakiye = t.musteriBakiye;
            db.SaveChanges();
            return RedirectToAction("Index");



        }

    }
}