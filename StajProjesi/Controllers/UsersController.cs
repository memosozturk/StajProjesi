﻿using StajProjesi.Models.DataContext;
using StajProjesi.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;


namespace StajProjesi.Controllers
{
    public class UsersController : Controller
    {
        StajDBContext db = new StajDBContext();
        // GET: Users
        public ActionResult Index()
        {
            db.Configuration.LazyLoadingEnabled = false;
            return View(db.Users.Include("UserUnvan").ToList());
            
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        { db.Configuration.LazyLoadingEnabled = false;
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

        //// GET: Users/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}
        [HttpGet]
        public ActionResult Create()
        {
            List<SelectListItem> degerler = (from x in db.Unvan.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.UnvanAdi,
                                                 Value=x.Unvanid.ToString()
                                             }).ToList();
            
            ViewData["dgr"] = degerler;
            return View();
        }
        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Users users)
        {

            var u = db.Unvan.Where(x => x.Unvanid == users.UserUnvan.Unvanid).FirstOrDefault();
            users.UserUnvan = u;
            db.Users.Add(users);
            db.SaveChanges();
            return RedirectToAction("Index");

           

        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            var users = db.Users.Where(x => x.Userid == id).SingleOrDefault();
            return View(users);
           
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, Users users)
        {
            if (ModelState.IsValid)
            {

                var u = db.Users.Where(x => x.Userid == id).SingleOrDefault();

                u.Userid = users.Userid;
                u.Eposta = users.Eposta;
                u.Unvanid = users.Unvanid;
                u.UserUnvan = users.UserUnvan;
                u.UserAd = users.UserAd;


                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
            
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();

            }
            return View(users);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Users users = db.Users.Find(id);
            db.Users.Remove(users);
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
