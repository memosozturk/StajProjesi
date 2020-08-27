using StajProjesi.Models.DataContext;
using StajProjesi.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StajProjesi.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        StajDBContext db = new StajDBContext();
        // GET: Task
        public ActionResult Index()
        {
            var sorgu = db.Task.Include("proje").ToList();
            return View(sorgu);
        }

        // GET: Task/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            Task task = db.Task.Find(id);
            if (task == null)
            {
                return HttpNotFound();

            }
            return View(task);
        }

        // GET: Task/Create
        public ActionResult Create()
        {
            List<SelectListItem> degerler = (from x in db.Proje.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.ProjeAdi,
                                                 Value = x.Projeid.ToString()
                                             }).ToList();

            ViewData["dgr"] = degerler;
            return View();
        }

        // POST: Task/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Task task)
        {
            var u = db.Proje.Where(x => x.Projeid == task.proje.Projeid).FirstOrDefault();
            task.proje = u;
            if (ModelState.IsValid)
            {
                db.Task.Add(task);
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(task);
        }

        // GET: Task/Edit/5
        public ActionResult Edit(int id)
        {
            var task = db.Task.Where(x => x.Taskid == id).SingleOrDefault();
            return View(task);
        }

        // POST: Task/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Task task)
        {
            if (ModelState.IsValid)
            {

                var t = db.Task.Where(x => x.Taskid == id).SingleOrDefault();

                t.Taskid = task.Taskid;
                t.TaskBaslik =task.TaskBaslik;
                t.TaskBaslik = task.TaskAciklama;
                t.TaskTeslimTarihi = task.TaskTeslimTarihi;
                t.Projeid = task.Projeid;
              //  t.users = task.users;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Task/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            Task task = db.Task.Find(id);
            if (task == null)
            {
                return HttpNotFound();

            }
            return View(task);
        }

        // POST: Task/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Task task = db.Task.Find(id);
            db.Task.Remove(task);
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
