using MVCSTOK.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSTOK.Controllers
{

    public class MüsteriController : Controller
    {
        MVCStokEntities entity = new MVCStokEntities();
        // GET: Müsteri
        public ActionResult Index(string p)
        {
            //var deger = entity.TBLMUSTERILER.ToList();
            var degerler = from d in entity.TBLMUSTERILER select d;
            if(!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.MUSTERIADI.Contains(p));
            }
            
            return View(degerler.ToList());
        }

        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERILER müsteri)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            entity.TBLMUSTERILER.Add(müsteri);
            entity.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SIL(int id)
        {
            var musteri = entity.TBLMUSTERILER.Find(id);
            entity.TBLMUSTERILER.Remove(musteri);
            entity.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult MusteriGetir(int id)
        {
            var musteri = entity.TBLMUSTERILER.Find(id);
            return View(musteri);
            //return View("MusteriGetir", musteri);
        }

        [HttpPost]
        public ActionResult MusteriGetir(TBLMUSTERILER musteri)
        {
        

            var musteri1 = entity.TBLMUSTERILER.Find(musteri.MUSTERIID);
            musteri1.MUSTERIADI = musteri.MUSTERIADI;
            musteri1.MUSTERISOYAD = musteri.MUSTERISOYAD;
            entity.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}