using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStokTakip.Models.Entity;


namespace MVCStokTakip.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        DbMvcStokEntities db = new DbMvcStokEntities();

        public ActionResult Index(string p)
        {
            //var urunler = db.tblUrunler.Where(x=>x.durum==true).ToList();
            var urunler = db.tblUrunler.Where(x => x.durum == true);
            if(!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(x => x.urunAd.Contains(p) && x.durum == true); 
            }
            return View(urunler.ToList());

          
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> ktg = (from x in db.tblKategori.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.kategoriAd,
                                            Value = x.kategoriId.ToString()
                                        }).ToList();
            ViewBag.drop = ktg; //Drop Ktgdeki degerleri tutar.

            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(tblUrunler t)
        {
            var ktgr = db.tblKategori.Where(x => x.kategoriId == t.tblKategori.kategoriId).FirstOrDefault();//listeden gelen verilerin degerlerini tutuyor
            t.tblKategori = ktgr;
            db.tblUrunler.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> kat = (from x in db.tblKategori.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.kategoriAd,
                                             Value = x.kategoriId.ToString()

                                         }).ToList();
            var ktgr = db.tblUrunler.Find(id);
            ViewBag.urunKategori = kat;
            return View("UrunGetir", ktgr);
        }
        public ActionResult UrunGuncelle(tblUrunler p)
        {
            var urun = db.tblUrunler.Find(p.urunId);
            urun.urunMarka = p.urunMarka;
            urun.urunSatisFiyat = p.urunSatisFiyat;
            urun.urunStok = p.urunStok;
            urun.urunAlisFiyat = p.urunAlisFiyat;
            urun.urunSatisFiyat = p.urunSatisFiyat;
            urun.urunAd = p.urunAd;
            var ktg = db.tblKategori.Where(x => x.kategoriId == p.tblKategori.kategoriId).FirstOrDefault();
            urun.urunKategori = ktg.kategoriId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)

        {

            var urunBul = db.tblUrunler.Find(id);

            urunBul.durum = false;

            db.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}