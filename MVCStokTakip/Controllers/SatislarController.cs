using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStokTakip.Models.Entity;

namespace MVCStokTakip.Controllers
{
    public class SatislarController : Controller
    {
        // GET: Satis
        DbMvcStokEntities db = new DbMvcStokEntities();
        public ActionResult Index()
        {
            var satislar = db.tblSatislar.ToList();
            return View(satislar);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            //Urunler
            List<SelectListItem> urun = (from x in db.tblUrunler.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.urunAd,
                                             Value = x.urunId.ToString()
                                         }).ToList();
            ViewBag.drop1 = urun;

            //Personeller
            List<SelectListItem> per = (from x in db.tblPersonel.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.personelAd +" "+ x.personelSoyad,
                                            Value = x.personelId.ToString()
                                        }).ToList();
            ViewBag.drop2 = per;

            //Musteriler
            List<SelectListItem> must = (from x in db.tblMusteri.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.musteriAd + " " + x.musteriSoyad,
                                             Value = x.musteriId.ToString()
                                         }).ToList();
            ViewBag.drop3 = must;


            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(tblSatislar p)
        {

            var urun = db.tblUrunler.Where(x => x.urunId == p.tblUrunler.urunId).FirstOrDefault();
            var musteri = db.tblMusteri.Where(x => x.musteriId == p.tblMusteri.musteriId).FirstOrDefault();
            var personel = db.tblPersonel.Where(x => x.personelId == p.tblPersonel.personelId).FirstOrDefault();

            p.tblUrunler = urun;
            p.tblMusteri = musteri;
            p.tblPersonel = personel;
            p.satisTarih =DateTime.Parse( DateTime.Now.ToShortDateString());
            db.tblSatislar.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}