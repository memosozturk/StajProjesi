using StajProjesi.Models.DataContext;
using StajProjesi.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StajProjesi.Controllers
{
    public class AdminController : Controller
    {
         StajDBContext db = new StajDBContext();
        // GET: Admin
        public ActionResult Index()
        {
            var sorgu = db.Admin.ToList();
            return View(sorgu);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Users users)
        {
            
            var login = db.Users.Where(x => x.Eposta == users.Eposta).SingleOrDefault();
            if (login != null)
            {
                if (login.Eposta == users.Eposta && login.Sifre == users.Sifre)
                {
                    Session["userid"] = login.Userid;
                    Session["Eposta"] = login.Eposta;
                    return RedirectToAction("Index", "Admin");

                }
            }
            ViewBag.Uyari = "Kullanıcı Adı veya Şifre Yanlış";
            return View(users);
        }
    }
}