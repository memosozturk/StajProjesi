using StajProjesi.Models.DataContext;
using StajProjesi.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace StajProjesi.Controllers
{
    public class GuvenlikController : Controller
    {
        StajDBContext db = new StajDBContext();
        // GET: Guvenlik
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Users users)
        {
            bool sonuc = Membership.ValidateUser(users.Eposta,users.Sifre);
            if (sonuc)
            {
                FormsAuthentication.RedirectFromLoginPage(users.Eposta,true);
                RedirectToAction("Admin","Index");

            }

            //var login = db.Users.Where(x => x.Eposta == users.Eposta && x.Sifre == users.Sifre).SingleOrDefault();
            //if (login != null)
            //{
            //    if (login.Eposta == users.Eposta && login.Sifre == users.Sifre)
            //    {

            //        Session["userid"] = login.Userid;
            //        Session["Eposta"] = login.Eposta;
            //        Session["Unvanid"] = login.Unvanid;
            //        Session["UserAd"] = login.UserAd;
            //        if (login.Unvanid.ToString() == "1")
            //        {


            //            return RedirectToAction("Index", "Admin");
            //        }
            //        else if (login.Unvanid.ToString() == "2")
            //        {
            //            return RedirectToAction("Index", "PoweredUser");
            //        }
            //    }
            //    return RedirectToAction("Index", "User");

            //}
            ViewBag.Uyari = "Kullanıcı Adı veya Şifre Yanlış";
            return View(users);
        }
    }
}