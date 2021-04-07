using MVCSTOK.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
namespace MVCSTOK.Controllers
{
    public class KategoriController : Controller
    {
        MVCStokEntities db = new MVCStokEntities();
        // GET: Kategori
        public ActionResult Index(int sayfa=1)
        {
            var degerler = db.TBLKATEGORILER.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKategori(TBLKATEGORILER kategori)
        {
            if(!ModelState.IsValid)
            {
                return View("YeniKategori");
            }

            db.TBLKATEGORILER.Add(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SIL(int id)
        {
            var kategori = db.TBLKATEGORILER.Find(id);
            db.TBLKATEGORILER.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.TBLKATEGORILER.Find(id);
            return View("KategoriGetir",ktgr);
        }
        [HttpPost]
        public ActionResult KategoriGetir(TBLKATEGORILER ktg)
        {
            var kategori = db.TBLKATEGORILER.Find(ktg.KATEGORIID);
            kategori.KATEGORIADI = ktg.KATEGORIADI;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public ActionResult KategoriGetir(TBLKATEGORILER ktg)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        db.TBLKATEGORILER.AddOrUpdate(ktg);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(ktg);
        //}

    }
}