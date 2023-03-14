using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
namespace MvcStok.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MvcDbStokEntities1 db = new MvcDbStokEntities1();
        public ActionResult Index()
        {
            var degerler = db.TBLURUNLER.ToList();
            return View(degerler);
         
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> degerler = (from i in db.TBLKATEGORI.ToList()
                                                                    select new SelectListItem
                                                                    {
                                                                        Text = i.KATEGORIAD,
                                                                        Value = i.KATEGORIID.ToString(),

                                                                    }).ToList();


            ViewBag.dgr = degerler;

            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(TBLURUNLER p1)
        {
            var ktg = db.TBLKATEGORI.Where(m => m.KATEGORIID == p1.TBLKATEGORI.KATEGORIID).FirstOrDefault();
            p1.TBLKATEGORI = ktg;
            db.TBLURUNLER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult SIL(int id)
        {
            var urun = db.TBLURUNLER.Find(id);
            db.TBLURUNLER.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}