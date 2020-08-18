using Microsoft.EntityFrameworkCore;
using StajProjesi.Models.DataContext;
using StajProjesi.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace StajProjesi.Controllers
{
    public class ProjeController : Controller
    {
        StajDBContext db = new StajDBContext();
        // GET: Proje
        public ActionResult Index()
        {
            return View(db.Proje.ToList());
        }

        // GET: Proje/Details/5
        public ActionResult Details(int id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            Proje proje = db.Proje.Find(id);
            if (proje==null)
            {
                return HttpNotFound();

            }   
            return View(proje);
        }
        [HttpGet]
        public ActionResult Create()
        {
            List<SelectListItem> degerler = (from x in db.Users.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.UserAd,
                                                 Value = x.Userid.ToString()
                                             }).ToList();

            ViewData["Uservb"] = degerler;
            return View();
        }

        // POST: Proje/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Proje proje)
        {

            //var a = db.Proje.Where(x => x.Users.Userid == proje.Users.Userid).FirstOrDefault();
            //proje.Users.UserAd = a.ToString();
            //db.Proje.Add(proje);
            //db.SaveChanges();
            //return RedirectToAction("Index");
            return View();
        }

        // GET: Proje/Edit/5
        public ActionResult Edit(int id)
        {
            var proje = db.Proje.Where(x => x.Projeid == id).SingleOrDefault();
            return View(proje);
        }

        // POST: Proje/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, Proje proje)
        {
            if (ModelState.IsValid)
            {
                
                var p = db.Proje.Where(x => x.Projeid == id).SingleOrDefault();

                p.Projeid = proje.Projeid;
                p.ProjeAdi = proje.ProjeAdi;
                p.ProjeAciklama = proje.ProjeAciklama;

                  db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View();
        }

        // GET: Proje/Delete/5
        public ActionResult Delete(int id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            Proje proje = db.Proje.Find(id);
            if (proje==null)
            {
                return HttpNotFound();

            }
            return View(proje);
        }

        // POST: Proje/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proje proje = db.Proje.Find(id);
            db.Proje.Remove(proje);
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();

            }
            base.Dispose(disposing);
        }
    }
}
