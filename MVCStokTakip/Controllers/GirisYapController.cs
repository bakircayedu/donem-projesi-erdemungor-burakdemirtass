using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStokTakip.Models.Entity;
using System.Web.Security;

namespace MVCStokTakip.Controllers
{
    public class GirisYapController : Controller
    {
        // GET: GirisYap
        DbMvcStokEntities db = new DbMvcStokEntities();

        public ActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Giris(tblAdmin t)
        {
            var bilgiler = db.tblAdmin.FirstOrDefault(x => x.kullanici == t.kullanici && x.sifre == t.sifre);
            if(bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.kullanici, false);
                return RedirectToAction("Index", "Musteri");
            }
            else
            {
                
                return View();
            }
            return View();
        }
        public ActionResult CikisYap()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Giris");
        }
    }
}