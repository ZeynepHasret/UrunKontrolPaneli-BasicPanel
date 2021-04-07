using MVCSTOK.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSTOK.Controllers
{
    public class SatisController : Controller
    {
        MVCStokEntities entity = new MVCStokEntities();
        // GET: Satis
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(TBLSATISLAR satıs)
        {
            entity.TBLSATISLAR.Add(satıs);
            entity.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}