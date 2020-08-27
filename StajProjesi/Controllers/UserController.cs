using StajProjesi.Models.DataContext;
using StajProjesi.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StajProjesi.Models.Model;
namespace StajProjesi.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        StajDBContext db = new StajDBContext();
        // GET: User
        public ActionResult Index(int id)
        {
            db.Configuration.LazyLoadingEnabled = false;
            db.Users.Include("UserUnvan");
            var degerler = db.Users.Include("UserUnvan").ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();

            }

            return View(degerler);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
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

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
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

       
        
    }
}
