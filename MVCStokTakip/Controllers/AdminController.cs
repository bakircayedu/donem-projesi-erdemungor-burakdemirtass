using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStokTakip.Models.Entity;
using MVCStokTakip.Controllers;

namespace MVCStokTakip.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        DbMvcStokEntities db = new DbMvcStokEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniAdmin(tblAdmin p)
        {
            db.tblAdmin.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}