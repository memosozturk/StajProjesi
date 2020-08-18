using StajProjesi.Models.DataContext;
using StajProjesi.Models.Model;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

            var login = db.Users.Where(x => x.Eposta == users.Eposta && x.Sifre == users.Sifre ).SingleOrDefault();
            if (login != null)
            {
                if (login.Eposta == users.Eposta && login.Sifre == users.Sifre)
                {
                    
                    Session["userid"] = login.Userid;
                    Session["Eposta"] = login.Eposta;
                    Session["Unvanid"]=login.Unvanid;
                    Session["UserAd"] = login.UserAd;
                    if (login.Unvanid.ToString()=="1" || login.Unvanid.ToString() == "2")
                    {

                    
                    return RedirectToAction("Index","Admin");
}
                }
                
                
                    return RedirectToAction("Index","User");
                
            }
            ViewBag.Uyari = "Kullanıcı Adı veya Şifre Yanlış";
            return View(users);
        }
    }
}