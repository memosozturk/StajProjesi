using StajProjesi.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StajProjesi.Controllers
{
    [Authorize]
    public class PoweredUserController : Controller
    {
        StajDBContext db = new StajDBContext();
        // GET: PoweredUser
        public ActionResult Index()
        {

            var sorgu = db.Admin.ToList();
            return View(sorgu);
        }

        // GET: PoweredUser/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PoweredUser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PoweredUser/Create
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

        // GET: PoweredUser/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PoweredUser/Edit/5
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

        // GET: PoweredUser/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PoweredUser/Delete/5
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
