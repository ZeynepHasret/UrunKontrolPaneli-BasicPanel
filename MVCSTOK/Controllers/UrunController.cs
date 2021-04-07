using MVCSTOK.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSTOK.Controllers
{
    public class UrunController : Controller
    {
        MVCStokEntities db = new MVCStokEntities();
        // GET: Urun
        public ActionResult Index()
        {
            var urunler = db.URUNLER.ToList();
            return View(urunler);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            //var kategori = db.TBLKATEGORILER.ToList();
            //return View(kategori);
            List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIADI,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(URUNLER ürün)
        {
            var ktg = db.TBLKATEGORILER.Where(m => m.KATEGORIID == ürün.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            ürün.TBLKATEGORILER = ktg;
            db.URUNLER.Add(ürün);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SIL(int id)
        {
            var urun = db.URUNLER.Find(id);
            db.URUNLER.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIADI,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            var urun = db.URUNLER.Find(id);
            return View(urun);
        }
        [HttpPost]
        public ActionResult UrunGetir(URUNLER urun)
        {
           
            var urun1 = db.URUNLER.Find(urun.URUNID);
            urun1.URUNADI = urun.URUNADI;
            urun1.FIYAT = urun.FIYAT;
            urun1.STOK = urun.STOK;
            urun1.MARKA = urun.MARKA;
            var ktg = db.TBLKATEGORILER.Where(m => m.KATEGORIID == urun.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            urun1.URUNKATEGORI = ktg.KATEGORIID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}