using StajProjesi.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return View();
        }

        // GET: Proje/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proje/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Proje/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Proje/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Proje/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Proje/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
