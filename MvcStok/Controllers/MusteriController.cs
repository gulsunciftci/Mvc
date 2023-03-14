using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using PagedList;

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDbStokEntities1 db = new MvcDbStokEntities1();
        public ActionResult Index(int sayfa=1)
        {
            //var degerler = db.TBLMUSTERILER.ToList();
            var degerler = db.TBLMUSTERILER.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERILER p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.TBLMUSTERILER.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult SIL(int id)
        {
            var musteri = db.TBLMUSTERILER.Find(id);
            db.TBLMUSTERILER.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var ktgr = db.TBLMUSTERILER.Find(id);
            return View("MusteriGetir", ktgr);
        }
        public ActionResult Guncelle(TBLMUSTERILER p1)
        {
            var ktgr = db.TBLMUSTERILER.Find(p1.MUSTERIID);
            ktgr.MUSTERIAD = p1.MUSTERIAD;
            ktgr.MUSTERISOYAD = p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}